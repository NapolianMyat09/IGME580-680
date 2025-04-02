using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateCanvas : MonoBehaviour
{
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject buttonCanvas;

    private void Start()
    {
        Exit();
    }
    public void SwitchToMain()
    {
        buttonCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void Exit()
    {
        mainCanvas.SetActive(false);
        buttonCanvas.SetActive(false);
    }

}
