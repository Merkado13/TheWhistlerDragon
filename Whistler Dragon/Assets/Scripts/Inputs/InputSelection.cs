using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSelection : MonoBehaviour
{
    public bool GazeInputed = true;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
