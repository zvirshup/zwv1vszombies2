using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxController : MonoBehaviour
{
    public Rigidbody2D ammobox;
    private float startTime;
   

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= 8)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.ammo++;
            PlayerController.ammo++;
            PlayerController.ammo++;
            PlayerController.ammo++;
            PlayerController.ammo++;
            
            
            Destroy(gameObject);

        }

        
    }
}
