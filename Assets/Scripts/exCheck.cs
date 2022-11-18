using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exCheck : MonoBehaviour
{
    public bool[] actions = new bool[66];
    //public GameObject objects;
    //public GameObject test;
    private void Start()
    {
        getGObyID(30).GetComponent<directInteraction>().myTurn = true;
    }

    public GameObject getGObyID(int id)
    {
        /*if (id !=0)
        {
            Transform[] childs = objects.GetComponentsInChildren<Transform>();
            GameObject gameObject = null;
            for (int i = 1; i < childs.Length; i++)
            {
                if (childs[i].gameObject.GetComponent<idSet>() != null)
                    if (childs[i].gameObject.GetComponent<idSet>().id == id)
                        gameObject = childs[i].gameObject;
            }
            return gameObject;
        }
        else
            return null;*/
        idSet[] allObjWithID = FindObjectsOfType(typeof(idSet)) as idSet[];
        GameObject gameObject = null;
        foreach (var obj in allObjWithID)
        {
            if (obj.id == id)
                gameObject = obj.gameObject;
        }
        Debug.Log(gameObject);
        return gameObject;
    }
    
}
