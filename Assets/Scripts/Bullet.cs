using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.linearVelocity = transform.forward * speed;
        Destroy(gameObject, 3f); // Destroy the bullet after 2 seconds
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController
                = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.Die(); // Assuming TakeDamage is a method in PlayerController
            }
        }
        // Update is called once per frame
    }
    
}
