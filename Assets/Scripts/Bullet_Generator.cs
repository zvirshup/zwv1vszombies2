using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Generator : MonoBehaviour
{
    public Rigidbody2D bullet;
    public int frameDelta;
    private int counter;
    // Use this for initialization
    void Start()
    {
        counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        counter++;

        if (counter % frameDelta == 0)
        {
            for (int i = 0; i < Random.Range(1, 5); i++)
            {
                //Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
                //Vector3 wordPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Rigidbody2D bulletclone = (Rigidbody2D)Instantiate(bullet, wordPos, transform.rotation);
                
            }
        }
    }
}