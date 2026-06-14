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
    private bool isEnter;
    public bool isInside;
    private Vector3 vhclCoords;

    private void Update()
    {
        if (isEnter && !isInside && Keyboard.current.fKey.wasPressedThisFrame)
        {
            // ----- Debug ----- //
            Debug.Log("Entered!!");

            isInside = true;

            playerVcam.Priority = 10;
            vehicleTPPVcam.Priority = 20;
            if(playerMesh != null)
            {
                playerMesh.SetActive(false);
            }

            button.SetActive(false);
        }
        else if (isInside && Keyboard.current.fKey.wasPressedThisFrame)
        {
            // ----- Debug ----- //
            Debug.Log("Exit");

            isInside = false;

            playerVcam.Priority = 20;
            vehicleTPPVcam.Priority = 10;
            if(playerMesh != null)
            {
                vhclCoords = vehicleMesh.transform.position;
                playerMesh.SetActive(true);
                playerMesh.transform.position = new Vector3(vhclCoords.x+5,0.08f,vhclCoords.z); //<---------- gotta fix this 
            }
        }
    }

    public void onPlayerEnter()
    {
        if (!isInside)
        {
            isEnter = true;
        }
        button.SetActive(true);
    }
    public void onPlayerExit()
    {
        isEnter = false;
        button.SetActive(false);
    }
}
