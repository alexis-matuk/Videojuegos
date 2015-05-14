using UnityEngine;
using System.Collections;

public class TestCollider : MonoBehaviour {

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.gameObject.GetComponent<BoxCollider2D>())
		{
			col.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.GetComponent<BoxCollider2D>())
		{
			col.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
		}
		if(col.gameObject.GetComponent<Aphelion>())
		{
			col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		}
	}
	/*
	Para que funcione el hoyo negro hay que ponerle un rigidbody2d a aphelion
		haciendo eso se le puede quitar el rigidbody a los enemigos/powerups/items que no quieres que sean afectados por el hoyo negro
	WIP
	*/
}
