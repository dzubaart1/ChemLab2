using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class substanceCreating : MonoBehaviour
{
    public GameObject[] substancesPrefabs;
    [SerializeField] private Transform attachToSpoonPoint;
    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "activatingCorner")
        {
            int id = go.transform.parent.gameObject.GetComponent<idSet>().id;
            GameObject newSubs = Instantiate(substancesPrefabs[id], attachToSpoonPoint.position, Quaternion.identity);
            newSubs.transform.SetParent(attachToSpoonPoint);
            newSubs.GetComponent<SphereCollider>().enabled = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "caCl2")
        {
            if (collision.gameObject.transform.GetChild(0).GetComponent<BNG.SnapZone>() is null && collision.gameObject.transform.GetChild(0).GetComponent<BNG.SnapZone>().HeldItem == null)
            {
                GameObject newSubs = Instantiate(substancesPrefabs[1], attachToSpoonPoint.position, Quaternion.identity);
                newSubs.name = "CaCl2";
                newSubs.transform.SetParent(attachToSpoonPoint);
                newSubs.GetComponent<SphereCollider>().enabled = false;
                gameObject.GetComponent<AnswerCntrl>().InitiateAnswer();
            }
        }
    }
}
