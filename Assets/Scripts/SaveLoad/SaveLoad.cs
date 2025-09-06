using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad : MonoBehaviour
{
    public void SaveData(Game game)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = game.GetSaveFilePath();
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(game);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public SaveData LoadData(Game game)
    {
        string path = game.GetSaveFilePath();
        if(game.HasSaveFile())
        {
            BinaryFormatter formatter= new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData data=formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}
