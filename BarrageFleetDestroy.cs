using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarrageFleetDestroy : MonoBehaviour {

	GameObject explosion;
	Aphelion aphelion;
	
	void Start()
	{
		aphelion = GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>();//referencia a aphelion
		explosion = Resources.Load<GameObject>("Prefabs/explosion");
	}
	
	//mientras el trigger toque a la nave
	void OnTriggerStay2D(Collider2D col)
	{
		Wave wave = col.gameObject.GetComponent<Wave>();
		if(wave)//golpeado por onda
		{	
			hitByWave(wave);
		}
		laserFire laser = col.gameObject.GetComponent<laserFire>();
		if(laser)//golpeado por laser
		{
			hitByLaser(laser);
		}
	}
	
	//al primer golpe con la nave
	void OnTriggerEnter2D(Collider2D col)
	{
		Bullet bala = col.gameObject.GetComponent<Bullet>();
		if(bala)//golpeado por bala
		{
			hitByBullet(bala);
		}
		FireBurningBullet fireBurning = col.gameObject.GetComponent<FireBurningBullet>();
		if (fireBurning)//golpeado por bala fireBurning
		{
			hitByFireBurningBullet(fireBurning);
		}
	}
	
	//golpeado por bala fireBurning
	void hitByFireBurningBullet(FireBurningBullet fireBurning)
	{
		BarrageFleet fleet = gameObject.GetComponent<BarrageFleet>();
		fleet.reduceHealthBy(fireBurning.getDamage());//reducir vida
		Destroy (fireBurning.gameObject);//destruir bala
		SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
		sprite.color = new Color(1, 0, 0, 1);//cambiar de color a rojo
		StartCoroutine(retint (sprite));//corrutina para regresar a color normal
		if(fleet.getHealth() <= 0)//si se destruye la nave
		{
			aphelion.increaseScoreBy(fleet.getScore());//aumentar score
			aphelion.updateScore();
			Instantiate (explosion, transform.position, transform.rotation);//instanciar explosión
			Destroy (fleet.gameObject);//destruir nave
		}
	}
	
	//golpeado por láser
	//hace lo mismo que hitByFireBurningBullet, pero para el caso de láser
	void hitByLaser(laserFire laser)
	{
		BarrageFleet fleet = gameObject.GetComponent<BarrageFleet>();
		fleet.reduceHealthBy(laser.getDamage());
		SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
		sprite.color = new Color(1, 0, 0, 1);
		StartCoroutine(retint (sprite));
		if(fleet.getHealth() <= 0)
		{
			aphelion.increaseScoreBy(fleet.getScore());
			aphelion.updateScore();
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (fleet.gameObject);
		}
	}
	
	//golpeado por onda
	//hace lo mismo que hitByFireBurningBullet, pero para el caso de onda
	void hitByWave(Wave wave)
	{
		BarrageFleet fleet = gameObject.GetComponent<BarrageFleet>();
		fleet.reduceHealthBy(wave.getDamage());
		SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
		sprite.color = new Color(1, 0, 0, 1);
		StartCoroutine(retint (sprite));
		if(fleet.getHealth() <= 0)
		{
			aphelion.increaseScoreBy(fleet.getScore());
			aphelion.updateScore();
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (fleet.gameObject);
		}
	}
	
	//golpeado por bala normal
	//hace lo mismo que hitByFireBurningBullet, pero para el caso de bala normal
	void hitByBullet(Bullet bala)
	{
		BarrageFleet fleet = gameObject.GetComponent<BarrageFleet>();
		fleet.reduceHealthBy(bala.getDamage());
		Destroy (bala.gameObject);
		SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
		sprite.color = new Color(1, 0, 0, 1);
		StartCoroutine(retint (sprite));
		if(fleet.getHealth() <= 0)
		{
			aphelion.increaseScoreBy(fleet.getScore());
			aphelion.updateScore();
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (fleet.gameObject);
		}
	}
	
	//corrutina para regresar al color original
	IEnumerator retint(SpriteRenderer sprite)
	{
		yield return new WaitForSeconds(0.05f);//esperar .05 segundos
		sprite.color = new Color(1,1,1,1);//regresar a color original
	}
	
	//regresar animación de explosión
	public GameObject getExplosion()
	{
		return explosion;
	}
}
