using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMovement : MonoBehaviour
{
    Rigidbody boltRigidbody;
    [SerializeField] float fireSpeed;
    [SerializeField] float fireboltLifeTime = 20f;
    void Start()
    {
        
        boltRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        boltRigidbody.velocity = new Vector3(0, 0, fireSpeed);
        fireboltLifeTime -= Time.deltaTime;
        DestroyFireBolt();
        
    }
    void DestroyFireBolt()
    {
        if (fireboltLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cubes") 
        {
            Destroy(gameObject); 
        }
        
    }
}
