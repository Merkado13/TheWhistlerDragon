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

    private InputSelection selected;

    private void Start()
    {
        GameObject inputSelected = GameObject.Find("InputSelection");
        if (inputSelected)
        {
            selected = inputSelected.GetComponent<InputSelection>();

        }

    }

    public void SwapInputMode()
    {
        selected.GazeInputed = !selected.GazeInputed;
        ActiveDeactiveMicInput(!selected.GazeInputed);
    }

    public void ActiveDeactiveMicInput(bool micInputed)
    {
        if (micInputed)
        {
            foreach (MicInputedButton buttonH in highInputedButton)
                buttonH.activateMicInput();
            foreach (MicInputedButton buttonL in lowInputedButton)
                buttonL.activateMicInput();
        }
        else
        {
            foreach (MicInputedButton buttonH in highInputedButton)
                buttonH.deactivateMicInput();
            foreach (MicInputedButton buttonL in lowInputedButton)
                buttonL.deactivateMicInput();
        }

        sliderMic.SetActive(micInputed);
    }
}
