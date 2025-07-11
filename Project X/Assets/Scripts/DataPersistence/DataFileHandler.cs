using UnityEngine;
using System;
using System.IO;

public class DataFileHandler
{
    string dataDirPath;
    string dataFileName;

    public DataFileHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        string absPath = Path.Combine(dataDirPath, dataFileName);
        GameData dataToLoad = null;
        if (File.Exists(absPath))
        {
            try
            {
                string storedData;
                using (FileStream stream = new FileStream(absPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        storedData = reader.ReadToEnd();
                    }
                }

                dataToLoad = JsonUtility.FromJson<GameData>(storedData);
            }
            catch (Exception e)
            {
                Debug.Log("Failed to load data from file: " + absPath + "\n" + e);
            }
        }
        return dataToLoad;
    }

    public void Write(GameData data)
    {
        string absPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            //create directory
            Directory.CreateDirectory(Path.GetDirectoryName(absPath));

            string dataToWrite = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(absPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream)){
                    writer.Write(dataToWrite);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to write data to save file: " + absPath + "\n" + e);
        }
    }
}
