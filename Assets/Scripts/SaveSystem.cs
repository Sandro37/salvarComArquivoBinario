using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter binary = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.cjs";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        binary.Serialize(fileStream, data);
        fileStream.Close();
        Debug.Log("jogo salvo");
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.cjs";

        if (File.Exists(path))
        {
            BinaryFormatter binary = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = binary.Deserialize(stream) as PlayerData;

            stream.Close();

            Debug.Log("jogo carregado");
            return data;
        }
        else
        {
            Debug.Log($"Arquivo {path} não existe");
            return null;
        }

        
    }
}
