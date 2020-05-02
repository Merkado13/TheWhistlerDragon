using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour, IInputedControls
{
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
        return Input.GetKey(KeyCode.Space);
    }

}
