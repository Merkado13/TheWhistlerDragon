using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardControls : MonoBehaviour, IInputedControls
{
    public Quaternion GetPlayerRotation(Quaternion rotation, float rotationSpeed)
    {
        return Quaternion.identity;
    }

    public bool isShotInputActivated()
    {
        return false;
    }
}
