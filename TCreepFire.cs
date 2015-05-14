using UnityEngine;
using System.Collections;

public class TCreepFire : MonoBehaviour {

	float rate = .8f;
	GameObject smoke;
	
	
	void Start () {
		smoke = Resources.Load<GameObject>("Prefabs/SmokeTCreep");
		InvokeRepeating("Fire", 0.1f, rate);//disparar cada número de segundos random
	}
	
	void Fire () {
		Instantiate(smoke,transform.FindChild("tail").position, transform.FindChild("tail").rotation);
	}
}
