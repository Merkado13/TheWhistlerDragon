using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MicrophoneInput : MonoBehaviour
{

    public float MicLoudness;
    public float MicLoudnessinDecibels;
    public int frequency;
    private string _device;

    AudioClip _clipRecord;
    public AudioClip _recordedClip;
    int _sampleWindow = 128;

    [SerializeField]
    private GUIController controller;

    private AudioSource audioSource;

    //8 bandas de frecuencia
    private float[] frequencyBands = new float[8];

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //mic initialization
    public void InitMic()
    {
        if (_device == null)
        {
            _device = Microphone.devices[0];
        }
        _clipRecord = Microphone.Start(_device, true, 10, 44100);
        audioSource.clip = _clipRecord;
        audioSource.Play();
        _isInitialized = true;
    }

    public void StopMicrophone()
    {
        Microphone.End(_device);
        _isInitialized = false;
    }

    //get data from microphone into audioclip
    float MicrophoneLevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1); // null means the first microphone
        if (micPosition < 0) return 0;
        _clipRecord.GetData(waveData, micPosition);
        // Getting a peak on the last 128 samples
        for (int i = 0; i < _sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }

    float getMicrophoneFrecuency()
    {
        int windowF = 512;
        float[] spectrum = new float[windowF];

        int micPosition = Microphone.GetPosition(null) - (windowF + 1);

        int init = Mathf.Max(0, micPosition);

        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        float maxV = 0;
        int maxN = 0;
        for (int i = 0; i < windowF; i++)
        {
            if (!(spectrum[i] > maxV) || !(spectrum[i] > 0.0f))
                continue;

            maxV = spectrum[i];
            maxN = i;

        }

        float freqN = maxN;
        if (maxN > 0 && maxN < windowF - 1)
        {
            var dL = spectrum[maxN - 1] / spectrum[maxN];
            var dR = spectrum[maxN + 1] / spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);


        }
        float pitchValue = freqN * (44100) / windowF;

        return pitchValue;
    }

    void generateFrequencyBands()
    {
        for(int i = 0; i < frequencyBands.Length; i++)
        {
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if(i == 7)
            {
                sampleCount += 2;
            }

            for(int j = 0; j < sampleCount; j++)
            {

            }
        }
    }

    //get data from microphone into audioclip
    float MicrophoneLevelMaxDecibels()
    {

        float db = 20 * Mathf.Log10(Mathf.Abs(MicLoudness));

        return db;
    }


    void Update()
    {
        // levelMax equals to the highest normalized value power 2, a small number because < 1
        // pass the value to a static var so we can access it from anywhere
        MicLoudness = MicrophoneLevelMax();
        MicLoudnessinDecibels = MicrophoneLevelMaxDecibels();
        //DecibelsOfClip(_clipRecord);
        // Frequency = _recordedClip.frequency;
        frequency = (int)getMicrophoneFrecuency();
        if(controller)
            controller.UpdateMicSlider(MicLoudness);
    }

    bool _isInitialized;
    // start mic when scene starts
    void OnEnable()
    {
        InitMic();
        _isInitialized = true;
    }

    //stop mic when loading a new level or quit application
    void OnDisable()
    {
        StopMicrophone();
    }

    void OnDestroy()
    {
        StopMicrophone();
    }


    // make sure the mic gets started & stopped when application gets focused
    void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            //Debug.Log("Focus");

            if (!_isInitialized)
            {
                //Debug.Log("Init Mic");
                InitMic();
            }
        }
        if (!focus)
        {
            //Debug.Log("Pause");
            StopMicrophone();
            //Debug.Log("Stop Mic");

        }
    }

}
