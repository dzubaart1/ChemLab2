using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject collideWith;
    private AnswerCntrl answerCntrl;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == collideWith.name)
        {
            Debug.Log("name is " + collideWith.name);
            gameObject.GetComponent<AnswerCntrl>().InitiateAnswer();
        }
    }
}
