using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    LevelManager levelManager;
    Rigidbody cubeRigidbody;
    [SerializeField] float moveSpeed;
    float moveSpeedScale;
    void Start()
    {
        levelManager=FindObjectOfType<LevelManager>();  
        cubeRigidbody = GetComponent<Rigidbody>();  
    }

    
    void Update()
    {
        ArrangeMoveSpeed();
        MoveCubes();
        StopCubes();
    }
    void MoveCubes()
    {
        if(!levelManager.pauseGame)
        {
            cubeRigidbody.velocity = new Vector3(0, 0, -moveSpeed * moveSpeedScale);
        }
    }
   void StopCubes()
    {
        if(levelManager.pauseGame)
        {
            cubeRigidbody.velocity = Vector3.zero;
        }
        
    }

    void ArrangeMoveSpeed()
    { 
        moveSpeedScale = Mathf.Sqrt(levelManager.level)/2;
        if(moveSpeedScale < 1)
        {
            moveSpeedScale = 1;
        }
    }
  

}
