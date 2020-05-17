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

    [SerializeField]
    private int current_gold = 1000;
    public Text gold;
    [SerializeField]
    public GameObject gameOver;
    public bool playing = true;
    public void UpdateFireBar(float xScale)
    {
        fireBar.transform.localScale = new Vector3(xScale, 1, 1);
    }

    public void UpdateMicSlider(float micVolume)
    {
        micSlider.value = micVolume * 100;
    }
    public void UpdateGold(int g)
    {
        current_gold = current_gold - g;
        gold.text = current_gold.ToString();
        Debug.Log("current gold: " + current_gold);
        if (current_gold <= 0)
        {
            gameOver.SetActive(true);
            playing = false;

        }
    }
}
