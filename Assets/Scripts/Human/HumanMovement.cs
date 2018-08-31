using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    public static HumanMovement Instance;

    public float moveSpeed, rotateSpeed, stumbleTimerAmount, stumbleSpeed;
    public GameObject humanModel;
    public bool mainCharacter;
    public Vector3 movementVector;

    Vector3 stumbleDir;
    GameObject camObj;
    float xCameraOffset, zValue, startStumbleTimer, stumblingTimer;
    [HideInInspector] public Vector3 camFinalPos;
    Vector3 camOGPos;

    Vector3 newPos;
    bool stumbling;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        camObj = GetComponentInChildren<Camera>().gameObject;
        camFinalPos = Vector3.zero;
        camOGPos = camObj.transform.localPosition;
        startStumbleTimer = Time.timeSinceLevelLoad + stumbleTimerAmount * 2;
    }

    void Update()
    {
        zValue = Mathf.Clamp(Input.GetAxisRaw("Vertical"), 0, 1);
        movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, zValue);
    }

    private void FixedUpdate()
    {
        if (!stumbling && startStumbleTimer < Time.timeSinceLevelLoad)
        {
            stumbling = true;
            CalculateStubmleDir();
            stumblingTimer = Time.timeSinceLevelLoad + 1;
        }

        if (!stumbling)
        {
            humanModel.transform.position += (movementVector * Time.deltaTime);
        } else
        {
            if (stumblingTimer > Time.timeSinceLevelLoad)
            {
                humanModel.transform.position += ((movementVector + stumbleDir) * Time.deltaTime);
            } else
            {
                stumbling = false;
                startStumbleTimer = Time.timeSinceLevelLoad + stumbleTimerAmount;
            }
        }

        /*if (movementVector.x != 0)
        {
            xCameraOffset = Mathf.Clamp(humanModel.transform.localPosition.x - (movementVector.x * (moveSpeed + 1)),
                humanModel.transform.localPosition.x - 2, humanModel.transform.localPosition.x + 2f);

            camFinalPos = new Vector3(xCameraOffset, camOGPos.y, camOGPos.z);
        }
        else
        {
            camFinalPos = new Vector3(humanModel.transform.localPosition.x, camOGPos.y, camOGPos.z);
        }

        camObj.transform.localPosition = Vector3.Lerp(camObj.transform.localPosition, camFinalPos, 0.2f);*/
    }

    void CalculateStubmleDir()
    {
        stumbleDir = new Vector3(movementVector.x * stumbleSpeed, 0, movementVector.z * stumbleSpeed);
    }
}
