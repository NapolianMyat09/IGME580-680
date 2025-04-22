using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SliderScript : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] private TextMeshProUGUI _pitchValueText;
    [SerializeField] private TextMeshProUGUI _volumeValueText;
    [SerializeField] private TextMeshProUGUI _stereoPanValueText;
    [SerializeField] private TextMeshProUGUI _spatialBlendValueText;
    [SerializeField] private TextMeshProUGUI _reverbZoneMixValueText;

    const float volume = 1; //max volume is 1 or 100%

    [SerializeField] UnityEngine.UI.Slider volumeSlider;
    [SerializeField] UnityEngine.UI.Slider pitchSlider;
    [SerializeField] UnityEngine.UI.Slider stereoPanSlider;
    [SerializeField] UnityEngine.UI.Slider spatialBlendSlider;
    [SerializeField] UnityEngine.UI.Slider reverbZoneMixSlider;

    private void Start()
    {
        DisplayPitchValue(1);
        DisplayVolumeValue(1);
        DisplayStereoPanValue(0);
        DisplaySpatialBlendValue(0); //-1 to 1
        DisplayReverbZoneMixValue(0);
    }

    public void DisplayPitchValue(float value)
    {
        float roundedValue = Mathf.Round(value * 10f) / 10f;
        _pitchValueText.text = roundedValue.ToString();
        _audioSource.pitch = roundedValue;
    }

    public void DisplayVolumeValue(float value)
    {
        float valueInPercentage = 0;
        //What gets displayed
        valueInPercentage = Mathf.Round(value * 100f);
        _volumeValueText.text = valueInPercentage.ToString() + "%"; //the actual number, from 0 to 1.0

        //assigning to audiosource
        _audioSource.volume = value;
    }

    public void DisplayStereoPanValue(float value)
    {
        _stereoPanValueText.text = (Mathf.Round(value*10f)/10f).ToString();
        //assigning to audiosource
        _audioSource.panStereo = value;
    }
    public void DisplaySpatialBlendValue(float value)
    {
        _spatialBlendValueText.text = (Mathf.Round(value * 10f) / 10f).ToString();
        //assigning to audiosource
        _audioSource.spatialBlend = value;
    }
    public void DisplayReverbZoneMixValue(float value)
    {
        float roundedValue = Mathf.Round(value * 10f) / 10f;
        _reverbZoneMixValueText.text = roundedValue.ToString();
        _audioSource.reverbZoneMix = roundedValue;
    }

}
