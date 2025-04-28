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
    [SerializeField] private TextMeshProUGUI _startDelayValueText;
    [SerializeField] private TextMeshProUGUI _repeatRateValueText;


    const float volume = 1; //max volume is 1 or 100%
    float startDelay;
    float repeatRate;

    [SerializeField] UnityEngine.UI.Slider volumeSlider;
    [SerializeField] UnityEngine.UI.Slider pitchSlider;
    [SerializeField] UnityEngine.UI.Slider stereoPanSlider;
    [SerializeField] UnityEngine.UI.Slider spatialBlendSlider;
    [SerializeField] UnityEngine.UI.Slider reverbZoneMixSlider;
    [SerializeField] UnityEngine.UI.Slider startDelaySlider;
    [SerializeField] UnityEngine.UI.Slider repeatRateSlider;


    private void Start()
    {
        volumeSlider.value = 100;
        pitchSlider.value = 1;
        stereoPanSlider.value = 0;
        spatialBlendSlider.value = 0.5f;
        reverbZoneMixSlider.value = 1;
        startDelaySlider.value = 0;
        repeatRateSlider.value = 0;

        DisplayPitchValue(1);
        DisplayVolumeValue(1);
        DisplayStereoPanValue(0);
        DisplaySpatialBlendValue(0.5f); //-1 to 1
        DisplayReverbZoneMixValue(1);
        DisplayStartDelayValue(0);
        DisplayRepeatRateValue(0);

        UpdateInvoke();
    }
    private void PlayAudio()
    {
        _audioSource.Play();
    }

    /// <summary>
    /// Allow users to change the offset of playing audio and the repeat rate, different from pitch which warps the audio
    /// </summary>
    void UpdateInvoke()
    {
        CancelInvoke("PlayAudio"); // Stop the previous InvokeRepeating
        InvokeRepeating("PlayAudio", startDelay, repeatRate); // Start new InvokeRepeating
    }

    public void DisplayStartDelayValue(float value)
    {
        float roundedValue = Mathf.Round(value * 10f) / 10f;
        _startDelayValueText.text = roundedValue.ToString();
        startDelay = roundedValue;
        //InvokeRepeating doesnt allow param changes so I implemented this way to do so
        UpdateInvoke();
    }

    public void DisplayRepeatRateValue(float value)
    {
        float roundedValue = Mathf.Round(value * 10f) / 10f;
        _repeatRateValueText.text = roundedValue.ToString();
        repeatRate = roundedValue;
        //InvokeRepeating doesnt allow param changes so I implemented this way to do so
        UpdateInvoke();
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
