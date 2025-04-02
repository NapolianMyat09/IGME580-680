using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Slider : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] private TextMeshProUGUI _pitchValueText;
    [SerializeField] private TextMeshProUGUI _volumeValueText;
    [SerializeField] private TextMeshProUGUI _stereoPanValueText;
    [SerializeField] private TextMeshProUGUI _spatialBlendValueText;
    [SerializeField] private TextMeshProUGUI _reverbZoneMixValueText;



    private float _pitchValue;
    private float _volumeValue;
    private float _stereoPanValue;
    private float _spatialBlendValue;
    private float _reverbZoneMixValue;

    public void DisplayPitchValue(float value)
    {
        _pitchValue = Mathf.Round(value*10f)/10f;
        _pitchValueText.text = _pitchValue.ToString();
    }

    public void DisplayVolumeValue(float value)
    {
        float valueInPercentage = 0;
        //What gets displayed
        valueInPercentage = Mathf.Round(value * 100f);
        _volumeValueText.text = valueInPercentage.ToString() + "%";

        //the actual number, from 0 to 1.0
        _volumeValue = value;
    }

    public void DisplayStereoPanValue(float value)
    {
        
        _stereoPanValueText.text = (Mathf.Round(value*10f)/10f).ToString();
        _stereoPanValue = value;
    }
    public void DisplaySpatialBlendValue(float value)
    {
        _spatialBlendValueText.text = (Mathf.Round(value * 10f) / 10f).ToString();
        _spatialBlendValue = value;
    }
    public void DisplayReverbZoneMixValue(float value)
    {
        _reverbZoneMixValue = Mathf.Round(value * 10f) / 10f;
        _reverbZoneMixValueText.text = _reverbZoneMixValue.ToString();
    }

    public void Update()
    {
        _audioSource.pitch = _pitchValue;
        _audioSource.volume = _volumeValue;
        _audioSource.reverbZoneMix = _reverbZoneMixValue;
        _audioSource.panStereo = _stereoPanValue;
        _audioSource.spatialBlend = _spatialBlendValue;

    }
}
