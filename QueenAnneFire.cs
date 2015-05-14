using UnityEngine;
using System.Collections;

public class QueenAnneFire : MonoBehaviour {
	 GameObject bullet;
	bool fired = false;
	
	void Start()
	{
		bullet = Resources.Load<GameObject> ("Prefabs/Misil");
	}

	void Update () {
		if (!fired) {
			fireMissiles ();
		} else {
			fired = false;
			gameObject.GetComponent<QueenAnneAI>().setInactive(2);
		}
	}

	void fireMissiles()
	{
		int amount = Random.Range (2, 7);
		for (int i = 0; i < amount; i++) {
			Instantiate (bullet, new Vector3(transform.position.x+Random.Range(-20,20),transform.position.y+Random.Range(-20,20),412), Quaternion.Euler(0,0,Random.Range(0,360)));//instanciar bala
		}
		fired = true;
	}
}
