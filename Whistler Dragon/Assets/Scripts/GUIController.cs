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

    public void UpdateFireBar(float xScale)
    {
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
        gameState.text = "GameOver";
        resumeButton.SetActive(false);
        restartButton.SetActive(true);
    }
}
