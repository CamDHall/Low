using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Follow : MonoBehaviour {
    public GameObject tempGizmo;
    public float destTimerAmount = 5, offset, moveSpeed, rotateSpeed, range;

    Vector3 destination;
    Quaternion lookRotation;
    Rigidbody rb;

    float destTimer = 0;
    Vector3 curveMidPoint;

	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (destTimer < Time.timeSinceLevelLoad)
        {
            curveMidPoint = Util.MidAngle(HumanMovement.Instance.humanModel.transform, 
                HumanMovement.Instance.humanModel.transform.right, offset);
            destination = (Util.RandAlongFlatCurve(curveMidPoint, transform.position.y, offset) - transform.position).normalized;
            lookRotation = Quaternion.LookRotation(destination);

            destTimer = Time.timeSinceLevelLoad + destTimerAmount;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(Vector3.Distance(transform.position, HumanMovement.Instance.humanModel.transform.position));
        if (Vector3.Distance(transform.position, HumanMovement.Instance.humanModel.transform.position) > range)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);
            rb.MovePosition(rb.position + (transform.forward * moveSpeed));
        }
    }
}
