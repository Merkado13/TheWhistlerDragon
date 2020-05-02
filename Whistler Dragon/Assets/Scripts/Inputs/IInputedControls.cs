using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputedControls
{
    Quaternion GetPlayerRotation(Quaternion rotation, float rotationSpeed);
    bool isShotInputActivated();
}
