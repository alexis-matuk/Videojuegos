using UnityEngine;
using System.Collections;

public class ShootingStarFire : MonoBehaviour {

	float rate = 0.8f;
	GameObject bullet;
	ShootingStar star;
	
	
	void Start () {
		InvokeRepeating("Fire", 0.1f, rate);//disparar cada número de segundos random
		bullet = Resources.Load<GameObject>("Prefabs/bullet_enemy");
		star = gameObject.GetComponent<ShootingStar>();
	}
	
	void Fire () {
		foreach(Transform child in transform)
		{
			GameObject bull = (GameObject) Instantiate (bullet, child.position, child.rotation);//instanciar bala
			bull.GetComponent<EnemyBullet>().setDamage(star.getDamage());//cambiar daño a daño de barrage
		}
	}
}
