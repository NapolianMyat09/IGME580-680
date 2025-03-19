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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCloseProximity(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            triggerObj.SetActive(true);
        }
    }
    void OnCloseProximityExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerObj.SetActive(false);
        }
    }


}
