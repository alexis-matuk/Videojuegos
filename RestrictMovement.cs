using UnityEngine;
using System.Collections;

public class RestrictMovement : MonoBehaviour {

void Update(){
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
