using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MicInputType {HIGH, LOW};

[RequireComponent(typeof(GVRButton))]
public class MicInputedButton : MonoBehaviour
{
    [SerializeField]
    public MicInputType type;

    [SerializeField]
    private MicrophoneInput mic;
    private bool useMic = false;
    private GVRButton button;

    private void Awake()
    {
        button = GetComponent<GVRButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (useMic)
        {
            if (type == MicInputType.HIGH && mic.isHighPitched()){

                button.upLoad();
                Debug.Log("Vamos con el HIGH");

            }else if (type == MicInputType.LOW && mic.isLowPitched())
            {
                button.upLoad();
            }
            else
            {
                button.downLoad();
            }
        }
    }

    public void activateMicInput()
    {
        useMic = true;
        //button.setIsBeingActivated(true);
        button.setIsGazeInteractive(false);
        Debug.Log("Activado");
    }

    public void deactivateMicInput()
    {
        useMic = false;
        //button.setIsBeingActivated(false);
        button.setIsGazeInteractive(true);

    }
}
