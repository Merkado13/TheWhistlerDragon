using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour, IInputedControls
{
    [SerializeField]
    private MicrophoneInput micInput;

    [SerializeField]
    public bool usingMic = true;

    private const float MIC_TREESHOLD_DB = -50;

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
            return Input.GetKey(KeyCode.Space);
        }
        else
        {
            return micInput.MicLoudnessinDecibels >= MIC_TREESHOLD_DB;
        }
    }

}
