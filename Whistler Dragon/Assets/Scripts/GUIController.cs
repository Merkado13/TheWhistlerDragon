using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject fireBar;

    [SerializeField]
    private Slider micSlider;

    public void UpdateFireBar(float xScale)
    {
        fireBar.transform.localScale = new Vector3(xScale, 1, 1);
    }

    public void UpdateMicSlider(float micVolume)
    {
        micSlider.value = micVolume * 100;
    }
}
