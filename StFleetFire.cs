using UnityEngine;
using System.Collections;

//script que maneja los disparos de StFleet
public class StFleetFire : MonoBehaviour {
/*Declaración de variables*/
	public float minTime = 4f;
	public float maxTime = 6f;
	public float rate = 0.02f;
	public GameObject bullet;
	Sprite yellowBull;
	
	
	void Start () {
		InvokeRepeating("Fire", Random.Range(0.2f,1f), Random.Range(minTime, maxTime));//disparar cada número de segundos random
		yellowBull = Resources.Load<Sprite>("Sprites/yellowBull");//bala amarilla para barrage
	}
	
	void Fire () {
		StFleet stFleet = gameObject.GetComponent<StFleet>();
		BarrageFleet barr = gameObject.GetComponent<BarrageFleet>();
		if(stFleet)
		{
			GameObject bull = (GameObject) Instantiate (bullet, transform.Find("tip").position, transform.Find("tip").rotation);//instanciar bala
			bull.GetComponent<EnemyBullet>().setDamage(stFleet.getDamage());
		}
		else if(barr)
		{
			GameObject bull = (GameObject) Instantiate (bullet, transform.Find("tip").position, transform.Find("tip").rotation);//instanciar bala
			bull.GetComponent<EnemyBullet>().setDamage(barr.getDamage());//cambiar daño a daño de barrage
			bull.GetComponent<SpriteRenderer>().sprite = yellowBull;//cambiar sprite
		}
	}
	
}
