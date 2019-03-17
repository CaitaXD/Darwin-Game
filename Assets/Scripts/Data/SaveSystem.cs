using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void SaveData (PlayerInfo info)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+ "/info.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        Data saveInfo = new Data(info);
        formatter.Serialize(stream, saveInfo);
        stream.Close();

    }
    public static void SaveAudioData(AudioReader audio)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/audio.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        Data audioInfo = new Data(audio);
        formatter.Serialize(stream, audioInfo);
        stream.Close();


    }

    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "/info.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Data saveInfo = formatter.Deserialize(stream) as Data;
            stream.Close();

            return saveInfo;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static Data LoadAudioData()
    {
        string path = Application.persistentDataPath + "/audio.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
           Data audioInfo = formatter.Deserialize(stream) as Data;
            stream.Close();

            return audioInfo;
        }
        else
        {
            Debug.LogError("Volume file not found in " + path);
            return null;
        }
    }

}
