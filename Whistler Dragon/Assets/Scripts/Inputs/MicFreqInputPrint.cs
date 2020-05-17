using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicFreqInputPrint : MonoBehaviour
{

    public Text text;
    private MicrophoneInput mic;

    private void Awake()
    {
        mic = GetComponent<MicrophoneInput>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = mic.frequency.ToString();
    }
}
