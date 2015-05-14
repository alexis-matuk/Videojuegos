using UnityEngine;
using System.Collections;

public class HoleBulletFire : MonoBehaviour {

	public int bulletSpeed=200;
	void Update () {
		//trasladar bala hacia adelante
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
