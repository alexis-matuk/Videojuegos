using UnityEngine;
using System.Collections;

public class KamikazeAI : MonoBehaviour {

	Transform target; //Aphelion
	float moveSpeed; //velocidad
	float rotationSpeed;
	Transform myTransform; //posición de StFleet
	
	void Start()
	{
		myTransform = transform;
		rotationSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>().getSpeed();
		moveSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>().getSpeed()/1.5f;
		
	}
	
	//rotar hacia el jugador
	void RotateToPlayer()
	{
		float x = target.position.x - myTransform.position.x;
		float y = target.position.y - myTransform.position.y;
		float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg;//cambiar vector dirección a ángulo
		transform.parent.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,-angle),Time.deltaTime*rotationSpeed);
		transform.parent.parent.rotation = transform.parent.rotation;
	}
	
	void Update () {
		target = GameObject.FindWithTag("Player").transform; //actualizar posición de jugador cada frame
		RotateToPlayer();//rotar hacia jugador
		transform.parent.transform.parent.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0,1*moveSpeed));//moverse hacia adelante
		transform.parent.position = transform.parent.parent.position;
		transform.position = transform.parent.position;
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
