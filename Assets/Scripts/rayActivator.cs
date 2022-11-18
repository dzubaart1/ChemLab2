using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rayActivator : MonoBehaviour
{
    public GameObject leftRay;
    public GameObject rightRay;
    public InputActionProperty leftIAP;
    public InputActionProperty rightIAP;
    

    void Update()
    {
        leftRay.SetActive(leftIAP.action.ReadValue<float>() > 0.1f);
        rightRay.SetActive(rightIAP.action.ReadValue<float>() > 0.1f);
    }
}
