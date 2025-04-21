using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetParentFunction : MonoBehaviour
{
    private NavigateCanvas navigateCanvas;
    // Start is called before the first frame update
    void Start()
    {
        //create instance to get access to parent function while inside child prefab
        navigateCanvas = GetComponentInParent<NavigateCanvas>();
    }

    public void SwitchInstrumentPanel()
    {
        navigateCanvas.SwitchInstrumentPanel();
    }



}
