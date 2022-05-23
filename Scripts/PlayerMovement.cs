using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    LevelManager levelManager;
    Rigidbody playerRigidbody;

    public float moveSpeed;

    float xPosition;
    float xPositionMax = 40f;
    float xPositionMin = -40f;

    [SerializeField] Transform[] fireLocation;
    [SerializeField] GameObject plasmaBolt;
    public int firePointCount = 1;
    float fireCooldown = 0;
    
    

    void Start()
    {
        levelManager=FindObjectOfType<LevelManager>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        fireCooldown-= Time.deltaTime;    
        OnMove();
        OnFire();
        SetFireCooldown();
        LimitXPosition();
    }
    void OnMove()
    {
        float xMovement = Input.GetAxis("Horizontal") * moveSpeed;
        if(Input.GetAxis("Horizontal")!=0&&!levelManager.pauseGame)
        {
            playerRigidbody.velocity = new Vector3(xMovement,0,0);
        }
        else
        {
            playerRigidbody.velocity = Vector3.zero;   
        }
    }
    void OnFire()
    {
        for (int i = 0; i < firePointCount; i++)
        {
            if (Input.GetKey(KeyCode.Mouse0) && fireCooldown <= 0&&!levelManager.pauseGame)
            {
                Instantiate(plasmaBolt, fireLocation[i].position, Quaternion.identity);
              
            }
        }     
    }
    void SetFireCooldown()
    {
        if(fireCooldown<=0)
        {
            fireCooldown = 0.5f;
        }
    }
    void LimitXPosition()
    {
       xPosition = Mathf.Clamp(transform.position.x,xPositionMin , xPositionMax);
        transform.position=new Vector3(xPosition,transform.position.y,transform.position.z);
    }

}
