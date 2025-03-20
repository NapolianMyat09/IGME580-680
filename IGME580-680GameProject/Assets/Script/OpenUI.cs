using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    [SerializeField]
    GameObject triggerObj; //if camera gets close to this object, will trigger UI options
    [SerializeField]
    FirstPersonLook toggleCameraMovement; //will require so players dont move their camera around and can actually click the button to open UI
     
    // Start is called before the first frame update
    void Start()
    {
        triggerObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// When in close promixity of parent object button is assigned, shows UI button
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerObj.SetActive(true);
            toggleCameraMovement.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    /// <summary>
    /// When far from proximity of parent object button is assigned, hides UI button
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerObj.SetActive(false);
            toggleCameraMovement.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
