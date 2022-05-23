using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float playerMaxHealth=25;
    float fillamountCurrent=1;
    float fillamountNext=1;
    float delta=0.005f;
    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI playerHealtText;
    [SerializeField] GameObject player;

    void Update()
    {
        healthBar.fillAmount = fillamountCurrent;
        fillamountCurrent= Mathf.Lerp(fillamountCurrent,fillamountNext,delta); 
        DestoryPlayer();
        playerHealtText.text = "" + playerHealth + "/" + playerMaxHealth;
    }

    void DestoryPlayer()
    {
        if(playerHealth <= 0)
        {
            Destroy(player);
            SceneManager.LoadScene(1);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        fillamountNext = playerHealth / playerMaxHealth;
    }
  

}
