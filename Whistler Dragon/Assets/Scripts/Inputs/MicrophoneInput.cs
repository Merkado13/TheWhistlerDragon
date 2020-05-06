using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicrophoneInput : MonoBehaviour
{
    [SerializeField]
    private string selectedDevice;

    private AudioSource audioSource;

    private Slider microSlider;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Microphone.devices.Length > 0)
        {
            selectedDevice = Microphone.devices[0].ToString();
            audioSource.clip = Microphone.Start(selectedDevice, true, 10, AudioSettings.outputSampleRate);
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //audioSource.clip.
    }
}
