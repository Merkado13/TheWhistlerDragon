using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShower : MonoBehaviour
{

    public GameObject cube;

    public void showCube()
    {
        cube.SetActive(true);
    }

    public void hideCube()
    {
        cube.SetActive(false);
    }
    
}
