using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atributes : MonoBehaviour
{
    PlayerMovement playerMovement;
    LevelManager levelManager;
    PlayerHealth playerHealth;
    [SerializeField]Button skills;
    public int firePoint = 1;
    public float rateOfFire=0.5f;
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        levelManager = FindObjectOfType<LevelManager>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
       
    }
    public void IncreaseFirePoint()
    {
        if (levelManager.skillPoint >= 2)
        {
            playerMovement.firePointCount += 2;
            levelManager.skillPoint -= 2;
            skills.interactable = false;
        }
        

    }
    public void IncreaseHealth()
    {
        if (levelManager.skillPoint >= 1)
        {
            playerHealth.playerHealth += 25;
            playerHealth.playerMaxHealth+=25;
            levelManager.skillPoint--;
            skills.interactable = false;
        }
        
    }
    public void IncreaseBoltDamage()
    {
        if(levelManager.skillPoint >= 1)
        {
            levelManager.boltDamage += 1;
            levelManager.skillPoint -= 1;
            skills.interactable = false;
        }
        
    }
    public void InreaceRateOfFire()
    {
        if(levelManager.skillPoint>2)
        {
            rateOfFire = rateOfFire * 0.8f;
            levelManager.skillPoint -= 2;
            skills.interactable = false;
        }
        
    }
    public void IncreaseSpeed()
    {
        if(levelManager.skillPoint>=1)
        {
            playerMovement.moveSpeed = playerMovement.moveSpeed * 1.5f;
            levelManager.skillPoint--;
            skills.interactable = false;
        }
        
    }
    


}
