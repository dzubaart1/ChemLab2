using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directInteraction : MonoBehaviour
{
    public int objToInteracteID, actionNumber, nextObjID;
    public bool myTurn = false;
    [SerializeField] private GameObject exCheck;
    private void Start()
    {
        exCheck = GameObject.Find("exCheck");
    }
    private void OnTriggerEnter(Collider other1)
    {
        Transform other = other1.transform;
        checkRightTurn(other);
    }
    private void OnCollisionEnter(Collision other1)
    {
        Transform other = other1.transform;
        checkRightTurn(other);
    }

    private void checkRightTurn(Transform other)
    {
        if (other.gameObject.GetComponent<idSet>() != null)
            if (other.gameObject.GetComponent<idSet>().id == objToInteracteID && myTurn)
            {
                exCheck.GetComponent<exCheck>().actions[actionNumber] = true;
                exCheck.GetComponent<exCheck>().getGObyID(nextObjID).GetComponent<directInteraction>().myTurn = true;
                myTurn = false;
            }
    }
}
