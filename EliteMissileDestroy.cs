using UnityEngine;
using System.Collections;

public class EliteMissileDestroy : MonoBehaviour {

	float moveSpeed = 10000;
	void OnEnable()
	{
		Invoke ("Destroy", 3f);
	}
	
	void Destroy()
	{
		gameObject.SetActive(false);
		Destroy (gameObject);
	}
	
	void OnDisable()
	{
		CancelInvoke();
	}
	
	void Update()
	{
		GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0,1*moveSpeed));//moverse hacia adelante
		
		//restringir movimiento
		if (transform.position.x <= -890) {
			Destroy (this.gameObject);
		} else if (transform.position.x >= 890) {
			Destroy (this.gameObject);
		}
		
		if (transform.position.y <= -596) {
			Destroy (this.gameObject);
		} else if (transform.position.y >= 596) {
			Destroy (this.gameObject);
		}
	}
}
