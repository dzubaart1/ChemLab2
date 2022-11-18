using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class animatedInputHand : MonoBehaviour
{
    public InputActionProperty pinchAction;
    public InputActionProperty gripAction;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAction.action.ReadValue<float>();
        anim.SetFloat("Trigger", triggerValue);
        float gripValue = gripAction.action.ReadValue<float>();
        anim.SetFloat("Grip", gripValue);
    }
}
