using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileController : MonoBehaviour
{
    public Rigidbody2D zombie;
    private float speed;
    public static int score = 0;
    
    // Use this for initialization
    void Start()
    {
        speed = 0.5f;




    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(transform.position.x+speed , transform.position.y);
        TextMesh textObject = GameObject.Find("Score").GetComponent<TextMesh>();
        textObject.text = "Score: " + score;
    }
    void OnCollisionEnter2D(Collision2D objectYouCollidedWith)
    {
        if (objectYouCollidedWith.gameObject.CompareTag("zombie"))
        {
            score++;
            
            Destroy(objectYouCollidedWith.gameObject);
            Destroy(gameObject);
            
        }
        if (objectYouCollidedWith.gameObject.CompareTag("floor"))
        {
           
            Destroy(gameObject);
        }

    }



}