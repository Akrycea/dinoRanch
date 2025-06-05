using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler 
{
    private string DataDirPath = "";

    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName) 
    {
        this.DataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public DinoData Load()
    {
        //��czy nazwy tak �eby ka�dy system je rozczyta�
        string fullPath = Path.Combine(DataDirPath, dataFileName);

        DinoData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                //�adowanie zserializowanej data
                string dataToLoad = "";
                using (FileStream stream =  new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //odserializowanie data
                loadedData = JsonUtility.FromJson<DinoData>(dataToLoad);

            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to save file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(DinoData data) 
    {
        //��czy nazwy tak �eby ka�dy system je rozczyta�
        string fullPath = Path.Combine(DataDirPath, dataFileName);

        try
        {
            //tworzy droge do file zapisu je�li takowej jeszcze nie ma na urz�dzeniu
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serializuje C# na JSON (t�umaczy na inny j�zyk)
            string dataToStore = JsonUtility.ToJson(data, true);

            //u�ywa zserialozowanej data
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }

        }
        catch (Exception e) 
        {
            Debug.LogError("Error occured when trying to save file: " + fullPath + "\n" + e);
        }
    }

    public void Restart(DinoData data) 
    {
        string fullPath = Path.Combine(DataDirPath, dataFileName);

        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

        File.Delete (fullPath);
    }


}
