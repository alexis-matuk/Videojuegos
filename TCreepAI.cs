using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TCreepAI : MonoBehaviour {

	public float moveSpeed = 2500f; //velocidad
	Transform myTransform; //posición de StFleet
	bool reachedSpawner = false;
	bool choseSpawner = false;
	GameObject currentTarget;
	Vector3 targ;
	
	void Start()
	{
		myTransform = transform;
		targ = new Vector3(Random.Range(-800,800),Random.Range(-500,500),0);
	}
	
	//rotar hacia el jugador
	void RotateToSpawner()
	{
		if(Mathf.Abs(targ.x - transform.position.x)<=100)
		{
			if(Mathf.Abs(targ.y - transform.position.y)<=100)
			{
				reachedSpawner = true;
			}
		}
		
		if(!choseSpawner)
		{
			choseSpawner = true;
			reachedSpawner = false;
			targ = new Vector3(Random.Range(-800,800),Random.Range(-500,500),0);
			float x = targ.x - myTransform.position.x;
			float y = targ.y - myTransform.position.y;
			float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg;//cambiar vector dirección a ángulo
			transform.rotation = Quaternion.Euler(0,0,-angle);
			
		}
		if(choseSpawner && reachedSpawner)
		{
			reachedSpawner = false;
			choseSpawner = false;
		}
		
	}
	
	void Update () {
		RotateToSpawner();//rotar hacia jugador
		GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0,1*moveSpeed));//moverse hacia adelante
		//transform.Translate(new Vector3(0,moveSpeed*Time.deltaTime,0));
		restrictMovement();
		
	}
	
	//restringir movimiento
	void restrictMovement()
	{
		//restringir movimiento en X
		if (transform.position.x <= -830) {
			transform.position = new Vector3(-830, transform.position.y, transform.position.z);
		} else if (transform.position.x >= 830) {
			transform.position = new Vector3(830, transform.position.y, transform.position.z);
		}
		
		//restringir movimiento en Y
		if (transform.position.y <= -535) {
			transform.position = new Vector3(transform.position.x, -535, transform.position.z);
		} else if (transform.position.y >= 535) {
			transform.position = new Vector3(transform.position.x, 535, transform.position.z);
		}
	}
}
