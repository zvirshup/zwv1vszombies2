using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxGenerator : MonoBehaviour
{
    public Rigidbody2D ammobox;
    public int frameDelta;
    private int counter;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        counter++;

        if (counter % frameDelta == 0)
        {
            for (int i = 0; i < Random.Range(1, 5); i++)
            {
                Vector3 mousePos = new Vector3(Random.Range(-10, 10), Random.Range(-5, 4), 0f);

                Rigidbody2D bulletclone = (Rigidbody2D)Instantiate(ammobox, mousePos, transform.rotation);

            }
        }

        if (counter >= 50000)
        {
            Destroy(gameObject);
        }
    }
}
