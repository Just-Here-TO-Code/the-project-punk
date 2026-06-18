using UnityEngine;

public class enter_trigger : MonoBehaviour
{
    // UI manager script
    [Header("UI Script")]
    [SerializeField] UI_Manager UI_Manager; 
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            // ----- Debug ----- //
            // Debug.Log(other.gameObject.tag+" has entered the vehicle!!");
            setUIActive();
            UI_Manager.onPlayerEnter();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player"))
        {
            setUIinActive();
            UI_Manager.onPlayerExit();
        }
    }

    private void setUIActive()
    {
        if(UI_Manager != null)
        {
            UI_Manager.enabled = true;
        }
    }
    private void setUIinActive()
    {
        if(UI_Manager != null)
        {
            UI_Manager.enabled = false;
        }
    }
}
