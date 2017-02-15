using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour {
	public Rigidbody2D zombie;
	public int frameDelta;
	private int counter;
	// Use this for initialization
	void Start () {
		counter = 1;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
        
        if (counter % frameDelta == 0){
			for (int i = 0; i < Random.Range (1, 5); i++) {
                Vector3 position = transform.position;
                position.x += 15;
                transform.position = position;
                Rigidbody2D zombieclone = (Rigidbody2D)Instantiate (zombie, transform.position, transform.rotation);
                position.x -= 15;
                transform.position = position;
            }
	}
}
}