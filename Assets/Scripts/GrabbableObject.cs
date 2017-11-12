using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private GameObject setPoint;
    public bool isHeld;
    public bool isSet;
    public bool isReturning;

    private int countLimit = 2;
    private int index;
    private Vector3[] position;
    private Vector3[] velocity;
    private float lastTime;
    private float forceMult = 20f;

    private MeshCollider mc;
    private Rigidbody rb;

	void Start()
    {
        Init();
	}

    void Update()
    {
        RecordData();

        if (isHeld)
        {
            RecordData();
            rb.velocity = Vector3.zero;
        }

        else if(isSet)
        {
            this.transform.position = setPoint.transform.position;
            this.transform.eulerAngles = setPoint.transform.eulerAngles;
        }
	}

    private void Init()
    {
        setPoint = this.transform.parent.gameObject;
        isHeld = false;
        isSet = true;
        isReturning = false;

        index = 1;
        position = new Vector3[countLimit];
        position[0] = this.transform.position;
        velocity = new Vector3[countLimit];
        lastTime = Time.time;

        mc = GetComponent<MeshCollider>();
        rb = GetComponent<Rigidbody>();
    }

    private void RecordData()
    {
        position[index] = this.transform.position;

        Vector3 distance = position[index] - position[(index + 1) % 2];
        float time = Time.time - lastTime;
        velocity[index] = distance / time;

        lastTime = Time.time;
        index = (index + 1) % 2;
    }

    public void Grabbed()
    {
        isHeld = true;
        isSet = false;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
    }

    public void Released()
    {
        isHeld = false;
        rb.useGravity = true;
        rb.AddForce(rb.mass * velocity[index] * forceMult);
        StartCoroutine("ReturnToSet");
    }

    IEnumerator ReturnToSet()
    {
        isReturning = true;

        for(int i = 0; i < 3; i++)
        {
            Debug.Log(this.transform.name + " will return in " + (3 - i));
            yield return new WaitForSeconds(1f);
        }

        isSet = true;
        isReturning = false;
        rb.velocity = Vector3.zero;
    }
}
