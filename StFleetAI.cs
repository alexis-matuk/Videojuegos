using UnityEngine;
using System.Collections;

//script que maneja el comportamiento de StFleet
public class StFleetAI : MonoBehaviour {
/*Declaración de variables*/
	Transform target; //Aphelion
	public float moveSpeed = 2500f; //velocidad
	float rotationSpeed;
	Transform myTransform; //posición de StFleet
	
	void Start()
	{
		myTransform = transform;
		rotationSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>().getSpeed()*.05f;
		
	}
	
	//rotar hacia el jugador
	void RotateToPlayer()
	{
		float x = target.position.x - myTransform.position.x;
		float y = target.position.y - myTransform.position.y;
		float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg;//cambiar vector dirección a ángulo
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,-angle),Time.deltaTime*rotationSpeed);
	}
	
	void Update () {
		target = GameObject.FindWithTag("Player").transform; //actualizar posición de jugador cada frame
		RotateToPlayer();//rotar hacia jugador
		GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0,1*moveSpeed));//moverse hacia adelante
		//transform.Translate(new Vector3(0,2,0));
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