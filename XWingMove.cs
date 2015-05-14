using UnityEngine;
using System.Collections;

//script que maneja el movimiento de los PowerUps
public class XWingMove : MonoBehaviour {

	void Start()
	{
		transform.rotation = Quaternion.Euler(0,0,Random.Range(0,360));//rotación random
	}
	
	void Update () {
		transform.Translate (0, 150*Time.deltaTime, 0);//trasladar hacia adelante
		
		//restringir movimiento
		if (transform.position.x <= -830) {
			Destroy (gameObject);
		} else if (transform.position.x >= 830) {
			Destroy (gameObject);
		}
		
		if (transform.position.y <= -535) {
			Destroy (gameObject);
		} else if (transform.position.y >= 535) {
			Destroy (gameObject);
		}
	}
}
