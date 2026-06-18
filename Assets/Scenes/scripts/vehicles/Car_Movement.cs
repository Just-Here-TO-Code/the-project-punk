using UnityEngine;
using UnityEngine.InputSystem;

public class Car_Movement : MonoBehaviour
{
    [Header("UI Script")]
    [SerializeField] UI_Manager UI_Manager;
    private bool isDrive;
    private bool isFrwd = true;

    [Header("Movement")]
    public float thrstForce;
    public float brkForce;
    public float acclrtn;
    public float turnTrq;
    public float spdMtr = 0.0f;

    // keys bindings
    private bool isW;
    private bool isS;
    private bool isA;
    private bool isD;
    private bool isShift;
    private bool isSpace;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        // liner and rotational drag
        rb.linearDamping = 2.0f;
        rb.angularDamping = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        isDrive = UI_Manager.isInside;
        spdMtr = rb.linearVelocity.magnitude*3.6f; // < ----- speedoMeter;
        proccessInput();
    }

    // fixed physics loop at default 50fps for physics calculations to avoid issues like teleportation while lagging asn stuff (` ^ `)
    private void FixedUpdate()
    {
        processMovement();
    }

    private void proccessInput()
    {
        // linear
        isShift = Keyboard.current.shiftKey.isPressed;
        isSpace = Keyboard.current.spaceKey.isPressed;
        isW = Keyboard.current.wKey.isPressed;
        isS = Keyboard.current.sKey.isPressed;

        // turns
        isA = Keyboard.current.aKey.isPressed;
        isD = Keyboard.current.dKey.isPressed;
    }

    private void processMovement()
    {
        if (isDrive)
        {
            Transform vhclTrnsfm = transform;
            // speed dir -> momentum
            float frwdSpd = Vector3.Dot(rb.linearVelocity,vhclTrnsfm.forward);
            bool isMove = isW || isS;
            if (isMove)
            {
                float currThrst = thrstForce;
                if (isShift)
                {
                    currThrst *= acclrtn;
                }
                else if (isSpace)
                {
                    rb.AddForce(-1*rb.linearVelocity.normalized*brkForce,ForceMode.Acceleration);
                }
                if (isW)
                {
                    rb.AddRelativeForce(Vector3.forward*currThrst,ForceMode.Acceleration);
                }
                if (isS)
                {
                    rb.AddRelativeForce(Vector3.back*(currThrst/2),ForceMode.Acceleration);
                }
            }
            isFrwd = frwdSpd >=0;

            bool isTurning = isD || isA;
            if (isTurning && rb.linearVelocity.sqrMagnitude > 0.01f)
            {
                // ----- Debug ----- //
                // Debug.Log("Turning!!");
                Debug.Log(rb.angularVelocity);
                if (isD)
                {
                    if (isFrwd)
                    {
                        rb.AddRelativeTorque(Vector3.up*turnTrq,ForceMode.Acceleration);
                    }
                    else
                    {
                        rb.AddRelativeTorque(-1*Vector3.up*turnTrq,ForceMode.Acceleration);
                    }
                }
                else if (isA)
                {
                    if (isFrwd)
                    {
                        rb.AddRelativeTorque(-1*Vector3.up*turnTrq,ForceMode.Acceleration);
                    }
                    else
                    {
                        rb.AddRelativeTorque(Vector3.up*turnTrq,ForceMode.Acceleration);
                    }
                }
            }
        }
    }
}
