using UnityEngine;
using System.Collections;

public class HolePuncherFire : MonoBehaviour {

	float minTime = 6f;
	float maxTime = 8f;
	 GameObject bullet;
	Sprite yellowBull;
	HolePuncher punch;
	
	
	void Start () {
		InvokeRepeating("Fire", 1f, Random.Range(minTime, maxTime));//disparar cada número de segundos random
		bullet = Resources.Load<GameObject>("Prefabs/HoleBullet");
		punch = gameObject.GetComponent<HolePuncher>();
	}
	
	void Fire () {
		if(punch)
		{
			GameObject bull = (GameObject) Instantiate (bullet, transform.Find("tip").position, transform.Find("tip").rotation);//instanciar bala
			bull.GetComponent<EnemyBullet>().setDamage(punch.getDamage());
		}
	}
	
}
