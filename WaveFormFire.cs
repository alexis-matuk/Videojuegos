using UnityEngine;
using System.Collections;

public class WaveFormFire : MonoBehaviour {

	float rate = 0.15f;
	GameObject bullet;
	WaveForm wave;
	Sprite purpleBull;
	
	
	void Start () {
		InvokeRepeating("Fire", 0.1f, rate);//disparar cada número de segundos random
		purpleBull = Resources.Load<Sprite>("Sprites/purpleBullet");//bala amarilla para barrage
		bullet = Resources.Load<GameObject>("Prefabs/bullet_enemy");
		wave = gameObject.GetComponent<WaveForm>();
	}
	
	void Fire () {
		GameObject bull = (GameObject) Instantiate (bullet, transform.FindChild("tip").position, transform.FindChild("tip").rotation);//instanciar bala
		bull.GetComponent<EnemyBullet>().setDamage(wave.getDamage());//cambiar daño a daño de barrage
		bull.GetComponent<SpriteRenderer>().sprite = purpleBull;//cambiar sprite
	}
}
