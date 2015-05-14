using UnityEngine;
using System.Collections;

//clase que maneja el movimiento de la onda
public class waveScript : MonoBehaviour {

	public int bulletSpeed;
	void Update () {
	//trasladar onda hacia adelante
		transform.Translate (0,bulletSpeed*Time.deltaTime, 0);
		
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
