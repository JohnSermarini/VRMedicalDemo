using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public bool aHeld;
    public bool aFrameDown;
    public bool aFrameUp;
    public bool xHeld;
    public bool xFrameDown;
    public bool xFrameUp;

	void Start()
    {
        Init();
	}
	
	void Update()
    {
        // A
        aFrameDown = false;
        aFrameUp = false;
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            aHeld = true;
            aFrameDown = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.One))
        {
            aHeld = false;
            aFrameUp = true;
        }

        // X
        xFrameDown = false;
        xFrameUp = false;
		if(OVRInput.GetDown(OVRInput.Button.Three))
        {
            xHeld = true;
            xFrameDown = true;
        }
        else if(OVRInput.GetUp(OVRInput.Button.Three))
        {
            xHeld = false;
            xFrameUp = true;
        }
	}

    private void Init()
    {
        aHeld = false;
        aFrameDown = false;
        xHeld = false;
        xFrameDown = false;
    }

    public bool GetHandButton(bool isLeftHand)
    {
        if(isLeftHand)
        {
            return xHeld;
        }
        else
        {
            return aHeld;
        }
    }
}
