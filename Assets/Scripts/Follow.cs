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

	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        destination = Util.MidAngle(HumanMovement.Instance.humanModel.transform,
                            HumanMovement.Instance.humanModel.transform.right, transform.position.y, offset);
    }

    private void FixedUpdate()
    {
        /// Change to only worry about movement not player rotation
        ///
        ///
        if (Vector3.Distance(transform.position, destination) > range)
        {
            lookRotation = Quaternion.FromToRotation(transform.forward, destination - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);
            Vector3 changePos = Vector3.Lerp(rb.position, destination, moveSpeed);
            rb.MovePosition(changePos);
        }
    }
}
