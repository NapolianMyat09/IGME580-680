using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateCanvas : MonoBehaviour
{
    private GameObject mainCanvas;
    private GameObject buttonCanvas;
    private GameObject instrumentPanel;
    private GameObject bassDrumPanel;
    private GameObject kickDrumPanel;
    public static int count = 0;


    void Start()
    {
        //GameObject parent = GameObject.Find("GameManager");
        GameObject topParent = transform.parent == null ? gameObject : transform.root.gameObject; //get the root parent
        mainCanvas = topParent.transform.Find("MainCanvas").gameObject;
        buttonCanvas = topParent.transform.Find("ButtonCanvas").gameObject;
        instrumentPanel = mainCanvas.transform.Find("Background/InstrumentsPanel").gameObject;
        bassDrumPanel = mainCanvas.transform.Find("Background/BassDrumPanel").gameObject;
        kickDrumPanel = mainCanvas.transform.Find("Background/KickDrumPanel").gameObject;


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

    //Navigate Panels in MainCanvas
    public void SwitchInstrumentPanel()
    {
        instrumentPanel.SetActive(true);
        bassDrumPanel.SetActive(false);
        kickDrumPanel.SetActive(false);
    }

    public void SwitchBassDrumPanel()
    {
        instrumentPanel.SetActive(false);
        bassDrumPanel.SetActive(true);
        kickDrumPanel.SetActive(false);
    }
    public void SwitchKickDrumPanel()
    {
        instrumentPanel.SetActive(false);
        bassDrumPanel.SetActive(false);
        kickDrumPanel.SetActive(true);
    }

}
