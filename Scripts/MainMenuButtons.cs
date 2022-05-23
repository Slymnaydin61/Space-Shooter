using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] GameObject settingUi;
    [SerializeField] GameObject highscoreU�;
    [SerializeField] GameObject mainMenuUi;
    [SerializeField] GameObject soundButton,muteButton;
    [SerializeField] Toggle toggle;
    [SerializeField] Button button;
    public bool playMusic = true;
    void Start()
    {
        levelManager=FindObjectOfType<LevelManager>();
    }
    public void Ex�t ()
    {
        Application.Quit ();
    }
    public void OpenSettings()
    {
        settingUi.SetActive (true);
        mainMenuUi.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowHighscore()
    {
        highscoreU�.SetActive(true);
        mainMenuUi.SetActive(false);
    }
    public void ReturMainMenu()
    {
        settingUi.SetActive(false);
        mainMenuUi.SetActive(true);
    }
    public void MuteSound()
    {
        soundButton.SetActive (false);
        muteButton.SetActive (true);
        playMusic = false;

    }
    public void UnMuteSound()
    {
        soundButton.SetActive(true);
        muteButton.SetActive(false);
        playMusic = true;
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ReturnGame()
    {
        levelManager.tryExit = false;
    }

}
