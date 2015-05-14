using UnityEngine;
using System.Collections;

//script que maneja la bala en sí
public class BulletScript : MonoBehaviour {

	public int bulletSpeed;
	void Update () {
	//trasladar la bala hacia adelante
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
