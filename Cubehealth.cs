using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Cubehealth : MonoBehaviour
{
    
    LevelManager levelManager;
    PlayerHealth playerHealth;

    int cubeScore;              //Variable used for turn cubehealth to cube score at the beginning.
    int cubeHealth;             
    int cubeHealthMin = 0;
    int cubeHealthMax = 10;
    int cubeHealtScale;

    [SerializeField] TextMeshPro cubeHitPoint;
    [SerializeField] GameObject cubeDestroyParticleSystem;
    
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        IncreaseCubeHealth();                               
        playerHealth=FindObjectOfType<PlayerHealth>();    
        cubeHealth = Random.Range(cubeHealthMin, cubeHealtScale);
        cubeScore = cubeHealth;
    }

    void Update()
    {
        cubeHitPoint.text = "" + cubeHealth;//Writing cube health to text on cubes.
        DestroyCubes();
    }
    void OnTriggerEnter(Collider other)
    {  
        if (other.gameObject.tag == "Player") // conditions that makes cubes destorey an decrease player health.
        {
            playerHealth.playerHealth -= cubeHealth;
            Destroy(gameObject);
        }
        cubeHealth -= levelManager.boltDamage;//OnTrigger methods for decreasing cube health.
    }
    void DestroyCubes() //Methods for destroying cubes that less than 1 health and increase score.
    {
        if(cubeHealth<1)
        {
            Destroy(gameObject);
            levelManager.score = levelManager.score + cubeScore; // For increasing score and return it.
            //PlayDestroyEffect();
        }
    }
    void IncreaseCubeHealth() // Methods for increasing cubes max healt that scaled by level.I defined conditions to 10 because i have 17 skills and few of them increase damage.
    {
        if(levelManager.level<10)
        {
            cubeHealtScale =  (int)(Mathf.Sqrt(levelManager.level) * cubeHealthMax);
        }
        else
        {
            cubeHealtScale = (int)(Mathf.Sqrt(10) * cubeHealthMax);
        }
    }
    //void PlayDestroyEffect()
    //{
    //   // Instantiate(cubeDestroyParticleSystem, transform.position, Quaternion.identity);
    //}
    
}
