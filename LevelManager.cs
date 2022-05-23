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
    bool isLeveledUp;
    public bool tryExit;

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
        LevelCheat();
        PlayMusic();
        OpenCanvas();
        SetBools();
        OpenExitMenu();
        Debug.Log(tryExit);
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

    void OpenCanvas()
    {
        if(isLeveledUp)
        {
            skillCanvas.SetActive(true);
            spawner.gameObject.SetActive(false);
            pauseGame = true;
        }
        else
        {
            skillCanvas.SetActive(false);
            spawner.gameObject.SetActive(true);
            pauseGame = false;
        }
    }
    void OpenExitMenu()
    {
        if(tryExit)
        {
            Debug.Log("Escde oyun durmuyor gerizekalý");
            exitMenuCanvas.SetActive(true);
            pauseGame = true;
            
        }
        else
        {
            Debug.Log("Escde oyun durmuyor gerizekalý2");
            exitMenuCanvas.SetActive(false);
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
            tryExit = true;
            isLeveledUp = false;    
        }
        //if(tryExit&& Input.GetKey(KeyCode.Escape))
        //{
        //    tryExit = false;
        //}
    }

}
