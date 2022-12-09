using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour, IColiderInteraction
{
    [SerializeField] private string[] rightObjectName;
    private int i = 0;
    public void OnCollisionEnter(Collision collision)
    {
        ColissionDetecting(collision.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        ColissionDetecting(other.gameObject);
    }
    public void ColissionDetecting(GameObject collision)
    {
        if (i >= rightObjectName.Length)
            return;
        if (collision.name == rightObjectName[i])
        {
            gameObject.GetComponent<AnswerCntrl>().InitiateAnswer();
            i++;
        }
    }
}
