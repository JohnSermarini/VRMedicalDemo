using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private bool isHandInit;
    private GameObject leftFingerTip;
    private GameObject rightFingerTip;

	void Start()
    {
        Init();
	}
	
	void Update()
    {
		if(!isHandInit)
        {
            InitFingers();
        }
	}

    private void Init()
    {
        isHandInit = false;
    }

    private void InitFingers()
    {
        try
        {
            leftFingerTip = this.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject;
            rightFingerTip = this.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject;
            isHandInit = true;
        }
        catch
        {

        }
    }
}
