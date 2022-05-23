using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    AudioSource ambianceSound;
    MainMenuButtons mainMenuButtons;
    Spawner spawner;
    public int level;
    public TextMeshProUGUI scoreText, levelText, skilpointText;
    public int score;
    public int boltDamage=1;
    public int skillPoint;
    [SerializeField] GameObject skillCanvas;
    [SerializeField] GameObject exitMenuCanvas;
    public bool pauseGame=false;
    bool isLeveledUp,tryExit;
    

    void Start()
    {
        ambianceSound=GetComponent<AudioSource>();
        spawner=FindObjectOfType<Spawner>();
        mainMenuButtons=GetComponent<MainMenuButtons>();
    }
    void Update()
    {
        float nextLevel = Mathf.Ceil(((250 / 6) * (level * level) - 75 * level + 83.33f));
        scoreText.text = "" + score + "/" + nextLevel;
        levelText.text = "LEVEL:" + level;
        skilpointText.text = "Skill Point:" +""+ skillPoint;
        IncreaseLevel();
        CloseCanvas();
        LevelCheat();
        PlayMusic();
        OpenCanvas();
        OpenExitMenu();
    }
    void IncreaseLevel()
    { 
        if(score>(250/6)*(level*level)-75*level+83.33f)
        {
            level++;
            skillPoint++;
            isLeveledUp=true;

        }
    }
    void LevelCheat()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            level++;
            skillPoint++;
            isLeveledUp=true ;
        }
    }
    public void CloseCanvas()
    {
        if(!isLeveledUp)
        {
            skillCanvas.SetActive(false);
            spawner.gameObject.SetActive(true);
            pauseGame = false;
        }
    
    }
    void OpenCanvas()
    {
        if(isLeveledUp)
        {
            skillCanvas.SetActive(true);
            spawner.gameObject.SetActive(false);
            pauseGame = true;
        }
    }
    void OpenExitMenu()
    {
        if(tryExit)
        {
            pauseGame = true;
            exitMenuCanvas.SetActive(true);
        }
       
    }
    void PlayMusic()
    {
        if(mainMenuButtons.playMusic)
        {
            ambianceSound.mute= false;
        }
        else
        {
            ambianceSound.mute= true;
        }
    }
    public void SetBools()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            isLeveledUp = false;
            tryExit = true;
            if(tryExit&& Input.GetKey(KeyCode.Escape))
            {
                tryExit = false;
            }


        }
    }

}
