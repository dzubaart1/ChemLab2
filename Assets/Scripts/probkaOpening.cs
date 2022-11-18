using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class probkaOpening : MonoBehaviour
{
    [SerializeField] private GameObject actCorner;
    [SerializeField] private int idParentSubstance;
    private Vector3 startPos;
    private Vector3 startRot;
    private Vector3 startSca;
    [SerializeField] private GameObject exCheck;
    private bool isAttach;
    //private Rigidbody rBody;
    private void Start()
    {
        /*startPos = transform.localPosition;
        startRot = transform.localEulerAngles;
        Debug.Log("rotation " + startRot);
        startSca = transform.localScale;*/
        exCheck = GameObject.Find("exCheck");
        //rBody = GetComponent<Rigidbody>();
    }
    public void onDetach()
    {
        isAttach = false;
        //gameObject.transform.parent = null;
        //gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        actCorner.SetActive(true);
    }
    public void onAttach()
    {
        //gameObject.transform.parent = null;
        isAttach = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<idSet>() != null)
            if (collision.gameObject.GetComponent<idSet>().id == idParentSubstance && !isAttach)
            {
                //gameObject.transform.parent = exCheck.GetComponent<exCheck>().getGObyID(idParentSubstance).transform;
                //gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                /*gameObject.transform.localPosition = startPos;
                gameObject.transform.eulerAngles = startRot;
                gameObject.transform.localScale = startSca;*/
            }
                
    }
}
