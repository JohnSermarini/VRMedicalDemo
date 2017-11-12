﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    private InputController ic;
    private GameObject fingerTip;
    public GameObject pointer;
    private LineRenderer lr;

    public bool isLeftHand;
    private bool isHoldingObject;
    private bool isTipInit;
    private GameObject heldObject;
    public float heldDistance = 3f;

    void Start()
    {
        Init();
	}
	
	void FixedUpdate()
    {
        if(!isTipInit)
        {
            InitFingerTip();
            return;
        }

        Ray ray = new Ray(fingerTip.transform.position, transform.forward);
        RaycastHit hit;
        bool isHit = Physics.Raycast(ray, out hit, Mathf.Infinity);

        UpdateLineRenderer(hit.point, isHit);

        if(!isHoldingObject && ic.GetHandButton(isLeftHand))
        {
            if(isHit && hit.transform.tag == "Grabbable" && !hit.transform.GetComponent<GrabbableObject>().isReturning)
            {
                if(!isHoldingObject)
                {
                    isHoldingObject = true;
                    hit.transform.GetComponent<GrabbableObject>().Grabbed();
                    heldObject = hit.transform.gameObject;
                }
            }
        }

        else if(isHoldingObject && !ic.GetHandButton(isLeftHand))
        {
            isHoldingObject = false;
            heldObject.GetComponent<GrabbableObject>().Released();
            heldObject = null;
        }

        if(isHoldingObject)
        {
            Vector3 newPosition = fingerTip.transform.position + (ray.direction * heldDistance);
            heldObject.transform.position = newPosition;
        }
    }

    private void Init()
    {
        ic = GameObject.Find("InputController").GetComponent<InputController>();
        lr = this.GetComponent<LineRenderer>();

        isHoldingObject = false;
        isTipInit = false;
    }

    private void InitFingerTip()
    {
        try
        {
            fingerTip = this.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject;
            isTipInit = true;
        }
        catch
        {

        }
    }

    private void UpdateLineRenderer(Vector3 endPoint, bool isHit)
    {
        lr.SetPosition(0, fingerTip.transform.position);

        if (isHit)
        {
            pointer.transform.position = endPoint;
            lr.SetPosition(1, pointer.transform.position);

        }
        else
        {
            pointer.transform.position = new Vector3(500f, 500f, 500f);
            lr.SetPosition(1, fingerTip.transform.position);
        }

    }
}