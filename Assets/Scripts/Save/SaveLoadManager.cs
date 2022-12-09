using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Zenject.Asteroids;
using static Save;

public class SaveLoadManager : MonoBehaviour
{

    public DebugCanvasCntrl debugCanvasCntrl;
    private string filPath;

    public List<GameObject> gameObjects;
    void Start()
    {
        filPath = Application.persistentDataPath + "/save.gamesave";
    }

    public void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(filPath, FileMode.Create);

        Save save = new Save();
        save.SaveEnemyData(gameObjects);

        formatter.Serialize(fs, save);

        fs.Close();

        debugCanvasCntrl.CleanDebugText();
        foreach (GameObject obj in gameObjects)
        {
            debugCanvasCntrl.AddDebugText(obj.transform.position.ToString());
        }
    }

    public void LoadGame()
    {
        if (!File.Exists(filPath))
        {
            return;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(filPath, FileMode.Open);

        Save save = (Save)formatter.Deserialize(fs);
        fs.Close();

        int i = 0;
        debugCanvasCntrl.CleanDebugText();
        foreach (ObjectSaveData objectSave in save.objectSaveDatas)
        {
            debugCanvasCntrl.AddDebugText($"({objectSave.pos.x}, {objectSave.pos.y}, {objectSave.pos.z})");
            gameObjects[i].GetComponent<AnswerCntrl>().LoadData(objectSave);
        }
    }
}

[System.Serializable]
public class Save
{
    [System.Serializable]
    public struct Vec3
    {
        public float x, y, z;
        public Vec3 (float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [System.Serializable]
    public struct ObjectSaveData
    {
        public Vec3 pos;
        public ObjectSaveData(Vec3 pos)
        {
            this.pos = pos;
        }

    }

    public List<ObjectSaveData> objectSaveDatas = new List<ObjectSaveData>();

    public void SaveEnemyData(List<GameObject> objects)
    {
        foreach(GameObject obj in objects)
        {
            Vec3 vector = new Vec3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
            objectSaveDatas.Add(new ObjectSaveData(vector));
        }
    }
}
