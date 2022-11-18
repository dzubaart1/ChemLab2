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
}
