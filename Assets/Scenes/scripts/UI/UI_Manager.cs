using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerVcam;
    [SerializeField] CinemachineVirtualCamera vehicleTPPVcam;
    [SerializeField] GameObject playerMesh;
    [SerializeField] GameObject vehicleMesh;
    [SerializeField] GameObject button;

    [SerializeField] int playerCamPrty;
    [SerializeField] int vhclCamPrty;
    [SerializeField] Car_Movement vhclMvmnt;
    private bool isEnter;
    public bool isInside;
    private Vector3 vhclCoords;

    private void Update()
    {
        if(vhclMvmnt != null && vhclMvmnt.spdMtr == 0)
        {
            if (isEnter && !isInside && Keyboard.current.fKey.wasPressedThisFrame)
            {
                // ----- Debug ----- //
                Debug.Log("Entered!!");

                isInside = true;
                isEnter = false;

                playerVcam.Priority = vhclCamPrty;
                vehicleTPPVcam.Priority = playerCamPrty;
                if(playerMesh != null)
                {
                    playerMesh.SetActive(false);
                }

                button.SetActive(false);
            }
            if (!isEnter && isInside && Keyboard.current.rKey.wasPressedThisFrame)
            {
                // ----- Debug ----- //
                Debug.Log("Exit");

                isInside = false;
                vehicleTPPVcam.Priority = vhclCamPrty;

                playerVcam.Priority = playerCamPrty;
                vhclCoords = vehicleMesh.transform.position;

                if(playerMesh != null)
                {
                    playerMesh.SetActive(true);
                    playerMesh.transform.position = new Vector3(vhclCoords.x+2,0.08f,vhclCoords.z+1); //<---------- gotta fix this 
                }
            }
        }
    }

    // enter -----> relative to the trigger boundary(box collider)
    public void onPlayerEnter()
    {
        isEnter = true;
        isInside = false;
        button.SetActive(true);
    }
    public void onPlayerExit()
    {
        isEnter = false;
        isInside = false;
        button.SetActive(false);
    }
}
