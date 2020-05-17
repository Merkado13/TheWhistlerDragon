using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMicController : MonoBehaviour
{
    [SerializeField]
    private MicInputedButton highInputedButton;

    [SerializeField]
    private MicInputedButton lowInputedButton;

    [SerializeField]
    private GameObject sliderMic;

    private bool isMicInputed = false;

    public void swapInputMode()
    {
        isMicInputed = !isMicInputed;
        if (isMicInputed)
        {
            highInputedButton.activateMicInput();
            lowInputedButton.activateMicInput();
        }
        else{

            highInputedButton.deactivateMicInput();
            lowInputedButton.deactivateMicInput();
        }

        sliderMic.SetActive(isMicInputed);
    }
}
