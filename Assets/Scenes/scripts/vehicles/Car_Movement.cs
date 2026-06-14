using UnityEngine;
using UnityEngine.InputSystem;

public class Car_Movement : MonoBehaviour
{
    [Header("UI Script")]
    [SerializeField] UI_Manager UI_Manager;
    private bool isDrive;
    private bool isFrwd = true;

    [Header("Movement")]
    public float speed = 10.0f;
    public float acclrtn = 0.1f;
    public float rtnlSpd = 10.0f;
    public float rtnlAcclrtn = 0.1f;
    private float a = 0.0f;
    private float rA = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        processMovement();
    }

    private void processMovement()
    {
        isDrive = UI_Manager.isInside;
        if (isDrive)
        {
            Transform vhclTrnsfm = transform;
            bool isMove = Keyboard.current.wKey.isPressed || Keyboard.current.sKey.isPressed;
            if (isMove)
            {
                if (Keyboard.current.shiftKey.isPressed)
                {
                    a += acclrtn*Time.deltaTime;
                }
                else if (Keyboard.current.spaceKey.isPressed)
                {
                    a -= (acclrtn*1.2f)*Time.deltaTime;
                }
                if (Keyboard.current.wKey.isPressed)
                {
                    isFrwd = true;
                }
                if (Keyboard.current.sKey.isPressed)
                {
                    isFrwd = false;
                }
            }
            else
            {
                a -= (acclrtn*1.5f)*Time.deltaTime;
            }
            a = Mathf.Clamp(a,0,5);
            speed = Mathf.Clamp(speed,20,50);

            if(a > 0)
            {
                if (isFrwd)
                {
                    vhclTrnsfm.position += a*vhclTrnsfm.forward*speed*Time.deltaTime;
                }
                else
                {
                    vhclTrnsfm.position += -1*a*vhclTrnsfm.forward*speed/2*Time.deltaTime;
                }
            }

            bool isTurning = Keyboard.current.dKey.isPressed || Keyboard.current.aKey.isPressed;
            if (isTurning && a>0)
            {
                rA += rtnlAcclrtn*Time.deltaTime;
                rA = Mathf.Clamp(rA,1,5);
                if (Keyboard.current.dKey.isPressed)
                {
                    if (isFrwd)
                    {
                        vhclTrnsfm.Rotate(0.0f,rA*rtnlSpd*Time.deltaTime,0.0f);
                    }
                    else
                    {
                        vhclTrnsfm.Rotate(0.0f,-1*rA*rtnlSpd*Time.deltaTime,0.0f);
                    }
                }
                else if (Keyboard.current.aKey.isPressed)
                {
                    if (isFrwd)
                    {
                        vhclTrnsfm.Rotate(0.0f,-1*rA*rtnlSpd*Time.deltaTime,0.0f);
                    }
                    else
                    {
                        vhclTrnsfm.Rotate(0.0f,rA*rtnlSpd*Time.deltaTime,0.0f);
                    }
                }
            }
            else
            {
                rA = 1.0f;
            }
        }
    }
}
