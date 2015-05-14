using UnityEngine;
using System.Collections;

//movimiento de Aphelion
public class aphelionMovement : MonoBehaviour {
	float speed;
	bool controller = false;
	
	void Start()
	{
		speed = gameObject.GetComponent<Aphelion>().getSpeed();
		string[] joysticks = Input.GetJoystickNames();
		if(joysticks == null)
			controller =  false;
		else
			controller = true;
	}
	
	void Update () {
		float x = 0;
		float y = 0;
		if(!controller)
		{
			x = Input.GetAxis("HorizontalMovement1");
			y = Input.GetAxis("VerticalMovement1");
		}
		else
		{
			x = Input.GetAxis("HorizontalMovement");
			y = Input.GetAxis("VerticalMovement");
		}
		x = x * Time.deltaTime * speed;
		y = y * Time.deltaTime * speed;
		//trasladar a Aphelion cuando se mueva el joystick izquierdo
		transform.Translate(x,y,0.0f, Space.World);
		//gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(x,y)*500);
		restrictMovement();
	}
	
	//función para que restringir el movimiento. No salir de los límites establecidos
	void restrictMovement()
	{
		//límites de X
		if (transform.position.x <= -830) {
			transform.position = new Vector3(-830, transform.position.y, transform.position.z);
		} else if (transform.position.x >= 830) {
			transform.position = new Vector3(830, transform.position.y, transform.position.z);
		}
		
		//ĺímites de Y
		if (transform.position.y <= -535) {
			transform.position = new Vector3(transform.position.x, -535, transform.position.z);
		} else if (transform.position.y >= 535) {
			transform.position = new Vector3(transform.position.x, 535, transform.position.z);
		}
	}

	public void updateSpeed()
	{
		speed = gameObject.GetComponent<Aphelion>().getSpeed();
	}
}
