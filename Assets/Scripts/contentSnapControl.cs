using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contentSnapControl : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] private float rotX;

    private void Start()
    {
        checkRotation();
    }
    void Update()
    {
        checkRotation();
    }
    private void checkRotation()
    {
        rotX = transform.localEulerAngles.x;
        if (rotX > 0 && rotX < 250)
        {
            for (var i = content.transform.childCount - 1; i >= 0; i--)
            {
                var child = content.transform.GetChild(i);
                child.parent = null;
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.GetComponent<SphereCollider>().enabled = true;
                child.gameObject.AddComponent<activeStateChange>();
            }
        }
    }
}
