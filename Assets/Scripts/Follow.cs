using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Follow : MonoBehaviour {
    public GameObject tempGizmo;
    public float destTimerAmount = 5, offset, moveSpeed, rotateSpeed, range;

    Vector3 destination, offsetPos;
    Quaternion lookRotation;
    Rigidbody rb;

    float destTimer = 0;

	void Start () {
        rb = GetComponent<Rigidbody>();
        offsetPos = new Vector3(1 * offset, 0, 1);
    }
	
	// Update is called once per frame
	void Update () {
        destination = HumanMovement.Instance.humanModel.transform.position + 
            new Vector3(Mathf.Sin(Mathf.Deg2Rad * 45), 0, Mathf.Cos(Mathf.Deg2Rad * 45)) * 2;
        destination.y = transform.position.y;
    }

    private void FixedUpdate()
    {
        /// Change to only worry about movement not player rotation
        ///
        ///

        if(Vector3.Distance(rb.position, HumanMovement.Instance.humanModel.transform.position + offsetPos) > 1)
        {
            if (HumanMovement.Instance.movementVector.x > 0)
            {
                rb.position = Vector3.MoveTowards(rb.position,
                    HumanMovement.Instance.humanModel.transform.position + (1.5f * offsetPos),
                    Time.deltaTime);
            }
            else
            {
                rb.position = Vector3.MoveTowards(rb.position,
                    HumanMovement.Instance.humanModel.transform.position + offsetPos,
                    Time.deltaTime);
            }
        }

        if (Vector3.Distance(transform.position, destination) > range)
        {
            float rangeOfDog = Vector3.Distance(destination, HumanMovement.Instance.humanModel.transform.position);
            if (HumanMovement.Instance.movementVector != Vector3.zero)
            {
                transform.LookAt(destination);
            }
        }

        //Debug.DrawRay(transform.position, destination, Color.red, 5);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(HumanMovement.Instance.humanModel.transform.position + offsetPos, 
            new Vector3(1, 1, 1));
    }
}
