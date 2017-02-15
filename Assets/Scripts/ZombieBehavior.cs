using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
   
    public static int lives=8;
    public int frameDelta;
    private int counter;
    public Rigidbody2D zombie;
    private float speed;
    private float posY;
    // Use this for initialization
    void Start()
    {
        
        speed = Random.Range(0.008f, 0.03f);
        
        float[] randomLevels = new float[] { -4.5f, 2.5f, -1f };
        posY = randomLevels[Random.Range(0, randomLevels.Length)];



    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed, posY);
        
    }

    void OnCollisionEnter2D (Collision2D objectYouCollidedWith)
    {
        if (objectYouCollidedWith.gameObject.CompareTag("Player"))
        {
            
            lives--;
            TextMesh textObject = GameObject.Find("Lives").GetComponent<TextMesh>();
            textObject.text = "Lives: " + lives;
            Destroy(gameObject);
        }

        if (objectYouCollidedWith.gameObject.CompareTag("special"))
        {
            
            lives--;

            TextMesh textObject = GameObject.Find("Lives").GetComponent<TextMesh>();
            textObject.text = "Lives: " + lives;
            Destroy(gameObject);

        }
    }
}
