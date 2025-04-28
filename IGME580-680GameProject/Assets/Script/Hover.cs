using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string[] stringArray = new string[] { "Volume determines how loud or quiet an audio like sounds and music plays.",
        "Pitch in an AudioSource controls how high or low a sound plays. Think of it like speeding up or slowing down a song—higher pitch makes it sound faster and more high-pitched, while lower pitch makes it slower and deeper",
        "Spatial Blend controls how an audio source transitions between 2D and 3D sound. Think of it like deciding whether a sound should feel flat and everywhere (like background music) or positioned in space (like footsteps moving around you).",
        "Reverb Zone Mix controls how much an audio source is affected by the global Reverb Zones in your scene. Think of it like adjusting how much an echo or ambient effect influences a sound.",
        "Stereo Pan controls the left-right balance of a sound before any 3D spatialization is applied. Think of it like adjusting which speaker the sound comes from—whether it's fully left, fully right, or balanced in the center.",
        "Start Delay refers to the amount of time before an action or function begins after the game starts. You can use it to adjust when this sound plays.",
        "Repeat Rate refers to how often an action or function is executed at regular intervals. You can use to to allow the sound to repeat to your desire rhythm."
    };

    public int textIndex = 0;

    Transform secondCousin; //Text Object 
    Transform grandParentSibling;
    TextMeshProUGUI textString;

    // Start is called before the first frame update
    public void Start()
    {
        Transform grandParent = transform.parent.parent;
        //Debug.Log(grandParent.name);
        grandParentSibling = grandParent.parent.GetChild(3);
        secondCousin = grandParentSibling.GetChild(0).GetChild(0); // Adjust based on hierarchy
        Debug.Log(secondCousin.name);


        textString = secondCousin.GetComponent<TextMeshProUGUI>();
        grandParentSibling.gameObject.SetActive(false);
        Debug.Log(grandParentSibling + " set inactive");
        grandParentSibling.SetAsLastSibling();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("PointerEnter");
        ShowText(textIndex);
        Cursor.visible = false;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("PointerExit");
        HideText();
        Cursor.visible = true;
    }
    public void ShowText(int i)
    {
        grandParentSibling.gameObject.SetActive(true);
        Debug.Log("Set Active: " + true);

        textString.text = stringArray[i];
    }
    public void HideText()
    {
        grandParentSibling.gameObject.SetActive(false);
    }
}
