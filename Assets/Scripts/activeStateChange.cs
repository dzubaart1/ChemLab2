using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeStateChange : MonoBehaviour
{
    //[SerializeField] private Material[] cubeMaterials; // 0 -inactive, 1 - active
    private bool isGrab, isOnActivePoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "activePoint")
        {
            isOnActivePoint = true;
        }
        /*else if (!isOnActivePoint && other.gameObject.tag != "subs")
            Destroy(gameObject);*/
    }
    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag!= "activePoint" && !isOnActivePoint && collision.gameObject.tag != "subs")
            Destroy(gameObject);*/
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "activePoint")
        {
            isOnActivePoint = false;
        }
    }
    private void Update()
    {
        Debug.Log("is grab " + isGrab + ", is on active point" + isOnActivePoint);
        if (isOnActivePoint && !isGrab)
        {
            Debug.Log("RightActrion");
            //gameObject.GetComponent<MeshRenderer>().material = cubeMaterials[1];
        }
        //else
            //gameObject.GetComponent<MeshRenderer>().material = cubeMaterials[0];
    }
    public void onSelect()
    {
        isGrab = !isGrab;
    }
}
