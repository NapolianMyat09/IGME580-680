using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    [SerializeField]
    GameObject triggerObj; //if camera gets close to this object, will trigger UI options
    // Start is called before the first frame update
    

    void Start()
    {
        triggerObj.SetActive(false);
        Debug.Log("Set Inactive");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player triggers it
        {
            triggerObj.SetActive(true); // Show the UI
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerObj.SetActive(false); // Hide the UI
        }
    }

}
