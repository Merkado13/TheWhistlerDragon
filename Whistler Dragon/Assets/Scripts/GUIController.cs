using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject fireBar;

    [SerializeField]
    private Slider micSlider;

    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private Text gameState;
    [SerializeField]
    private GameObject resumeButton;
    [SerializeField]
    private GameObject restartButton;

    private int current_gold = 1000;
    
    public Text gold;   
    public Text texto;

    public Image lavalevel; 

    public bool playing = true;

    public void UpdateFireBar(float xScale)
    {
        lavalevel.fillAmount = xScale;

        fireBar.transform.localScale = new Vector3(xScale, 1, 1);
    }

    public void UpdateMicSlider(float micVolume)
    {
        micSlider.value = micVolume / 3000;
    }

    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ActivatePauseMenu()
    {
        gameState.text = "Pausa";
        menuPanel.SetActive(true);
        resumeButton.SetActive(true);
        restartButton.SetActive(false);
    }

    public void DeactivatePauseMenu()
    {
        menuPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameState.text = "Derrota";
        resumeButton.SetActive(false);
        restartButton.SetActive(true);
    }

    public void Victory()
    {
        gameState.text = "Victoria";
        resumeButton.SetActive(false);
        restartButton.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateGold(int g)
    {
        current_gold = current_gold - g;
        gold.text = current_gold.ToString();
        Debug.Log("current gold: " + current_gold);
        if (current_gold <= 0)
        {
            texto.text = "GAME OVER";
            playing = false;

        }
    }

}
