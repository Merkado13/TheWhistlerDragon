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

    [SerializeField]
    private ButtonMicController buttonMicController;

    private int current_gold = 1000;
    
    public Text gold;   
    public Text texto;

    public Image lavalevel; 

    public bool playing = true;


    private InputSelection selection;
    private bool alreadyApliedInputSelection = false;

    public void Start()
    {
        GameObject inputSelected = GameObject.Find("InputSelection");
        if (inputSelected)
        {
            selection = inputSelected.GetComponent<InputSelection>();
            if (!selection.GazeInputed)
            {
                buttonMicController.ActiveDeactiveMicInput(true);
            }
        }
    }

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
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }

    public void ActivatePauseMenu()
    {
        Time.timeScale = 0;
        gameState.text = "Pausa";
        menuPanel.SetActive(true);
        resumeButton.SetActive(true);
        restartButton.SetActive(false);
        AplyInpuSelection();
    }

    public void DeactivatePauseMenu()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 1;
        gameState.text = "Derrota";
        resumeButton.SetActive(false);
        restartButton.SetActive(true);
        AplyInpuSelection();
    }

    public void Victory()
    {
        Time.timeScale = 1;
        gameState.text = "Victoria";
        texto.text = "Victoria";
        resumeButton.SetActive(false);
        restartButton.SetActive(true);
        AplyInpuSelection();
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void AplyInpuSelection()
    {
        if (selection)
        {
            buttonMicController.ActiveDeactiveMicInput(!selection.GazeInputed);
        }
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
