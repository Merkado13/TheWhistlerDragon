using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour, IInputedControls
{
    [SerializeField]
    private MicrophoneInput micInput;

    public bool usingMic = true;

    private const float MIC_TREESHOLD_DB = -80;

    public Quaternion GetPlayerRotation(Quaternion rotation, float rotationSpeed)
    {
        Vector3 rot = rotation.eulerAngles;

        float yOffset = rot.y;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            yOffset -= rotationSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            yOffset += rotationSpeed;
        }

        rot = new Vector3(rot.x, yOffset, rot.z);

        return Quaternion.Euler(rot);
    }

    public bool isShotInputActivated()
    {
        if (!usingMic)
        {
            return Input.GetMouseButton(1) || Input.GetMouseButton(0);
        }
        else
        {
            return micInput.MicLoudnessinDecibels >= MIC_TREESHOLD_DB;
        }
    }

    public bool isInputValid()
    {
        if (!usingMic)
        {
            return true;
        }
        else
        {
            return micInput.frequency != 0;
        }
    }

    public bool isSmallShot()
    {
        if (!usingMic)
        {
            return Input.GetMouseButton(1);
        }
        else
        {
            return micInput.isHighPitched();
        }
    }

    public bool isBigShot()
    {
        if (!usingMic)
        {
            return Input.GetMouseButton(0);
        }
        else
        {
            return micInput.isLowPitched();
        }
    }
}
