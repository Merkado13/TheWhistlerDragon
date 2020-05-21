using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMicController : MonoBehaviour
{
    [SerializeField]
    private MicInputedButton[] highInputedButton;

    [SerializeField]
    private MicInputedButton[] lowInputedButton;

    [SerializeField]
    private GameObject sliderMic;

    [SerializeField]
    private bool isMicInputed = false;

    public void swapInputMode()
    {
        isMicInputed = !isMicInputed;
        if (isMicInputed)
        {
            foreach(MicInputedButton buttonH in highInputedButton)
                buttonH.activateMicInput();
            foreach (MicInputedButton buttonL in lowInputedButton)
                buttonL.activateMicInput();
        }
        else{

            foreach (MicInputedButton buttonH in highInputedButton)
                buttonH.deactivateMicInput();
            foreach (MicInputedButton buttonL in lowInputedButton)
                buttonL.deactivateMicInput();
        }

        sliderMic.SetActive(isMicInputed);
    }
}
