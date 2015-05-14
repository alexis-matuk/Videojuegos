using UnityEngine;
using System.Collections;

public class BarrageAI : MonoBehaviour {
	/*Declaración de variables*/
	Transform target; //Aphelion
	float moveSpeed = 2500; //velocidad
	float rotationSpeed; //velocidad de rotación
	Transform myTransform; //posición de StFleet
	
	void Start()
	{
		rotationSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>().getSpeed()*.03f;
		myTransform = transform;
		
	}
	
	//rotar hacia el jugador
	void RotateToPlayer()
	{
		float x = target.position.x - myTransform.position.x;
		float y = target.position.y - myTransform.position.y;
		float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg;//cambiar vector dirección a ángulo
		//GetComponent<Rigidbody2D>().MoveRotation(-angle);//rotar nave
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,-angle),Time.deltaTime*rotationSpeed);
		
	}
	
	void Update () {
		target = GameObject.FindWithTag("Player").transform; //actualizar posición de jugador cada frame
		RotateToPlayer();//rotar hacia jugador
		updateChildrenRotation();
		GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0,1*moveSpeed));//moverse hacia adelante
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
	
	void updateChildrenRotation()
	{
	//actualizar rotación de los hijos
		foreach (Transform child in transform)
		{
			child.rotation = transform.rotation;
		}
	}
	
}
