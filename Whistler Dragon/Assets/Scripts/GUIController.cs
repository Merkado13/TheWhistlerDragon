using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject fireBar;

    public void UpdateFireBar(float xScale)
    {
        fireBar.transform.localScale = new Vector3(xScale, 1, 1);
    }
}
