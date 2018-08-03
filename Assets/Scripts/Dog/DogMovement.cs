using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour {

    public static DogMovement Instance;

    public float moveSpeed, rotateSpeed;
    public GameObject dogModel;
    public bool mainCharacter;

    Vector3 movementVector;
    GameObject camObj;
    float xCameraOffset;
    Vector3 camFinalPos, camOGPos;
    Quaternion rot;

    private void Awake()
    {
        Instance = this;
    }

    void Start () {
        camObj = GetComponentInChildren<Camera>().gameObject;
        camFinalPos = Vector3.zero;
        camOGPos = camObj.transform.localPosition;
	}
	
	void Update () {
        movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
	}

    private void FixedUpdate()
    {
        if(movementVector.z != 0)
            transform.position += transform.forward * (movementVector.z * moveSpeed);

        rot = Quaternion.Euler(0,  (movementVector.x * rotateSpeed), 0);
        transform.Rotate(rot.eulerAngles);

        if (movementVector.x != 0)
        {
            xCameraOffset = Mathf.Clamp(dogModel.transform.localPosition.x - (movementVector.x * (moveSpeed + 1)),
                dogModel.transform.localPosition.x - 2, dogModel.transform.localPosition.x + 2f);

            camFinalPos = new Vector3(xCameraOffset, camOGPos.y, camOGPos.z);
        } else
        {
            camFinalPos = new Vector3(dogModel.transform.localPosition.x, camOGPos.y, camOGPos.z);
        }

        camObj.transform.localPosition = Vector3.Lerp(camObj.transform.localPosition, camFinalPos, 0.2f);
    }
}
