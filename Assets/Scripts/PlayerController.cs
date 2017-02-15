using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    
    public AudioSource gameover;
    public AudioSource death;
    public AudioSource reload;
    public static int ammo=100;
    public Rigidbody2D bullet;
    public int speed = 5;
    private int logicvar = 0;
    private Rigidbody2D player1;
    private SpriteRenderer playerSprite;
    public Rigidbody2D projectile;
    private string spriteDirection;
    private Animator animation1;
    public int frameDelta;
    private int counter;
    public AudioSource laser;
    // Use this for initialization
    void Start()
    {
        player1 = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        spriteDirection = "right";
        animation1 = GetComponent<Animator>();

        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");
        int temp=0;
        
        
        if (ZombieBehavior.lives == 0) { gameover.Play();
            TextMesh textObject1 = GameObject.Find("GameOverText").GetComponent<TextMesh>();
            textObject1.text = "Game Over";
            Time.timeScale = 0;
        }

        if (Input.GetMouseButtonDown(0)&&logicvar==1)
        { logicvar = 0; }
        else if (Input.GetMouseButtonDown(0) && logicvar == 0)
        { logicvar = 1; }
        if (logicvar == 1 && ammo != 0)
        {
            animation1.SetBool("Firing", true);
            animation1.SetBool("Not Firing", false);
            counter++;
            speed = 1;
            if (counter % frameDelta == 0)
            {
                Vector3 mousePos = new Vector3(player1.transform.position.x, player1.transform.position.y, 0f);
                Vector3 wordPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Rigidbody2D bulletclone = Instantiate(bullet, mousePos, transform.rotation);
                ammo--;
                laser.Play();
            }
        }
        else
        {
            animation1.SetBool("Not Firing", true);
            animation1.SetBool("Firing", false);
            speed = 7;
        }

        ;
        TextMesh textObject = GameObject.Find("Ammo").GetComponent<TextMesh>();
        textObject.text = "Ammo: "+ammo;


        Vector3 move = new Vector3(moveHorizontal, moveVertical, 0);
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            spriteDirection = "left";
            //playerSprite.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            spriteDirection = "right";
            //playerSprite.flipX = false;

        }

    }

    void OnCollisionEnter2D(Collision2D objectYouCollidedWith)
    {
        if (objectYouCollidedWith.gameObject.CompareTag("Ammo"))
        {
            reload.Play();
        }
        if (objectYouCollidedWith.gameObject.CompareTag("zombie"))
        {
            gameObject.SetActive(false);
            death.Play();
            player1.transform.position = new Vector3(-7, -2, 0);
            gameObject.SetActive(true);
        }

    }
}
