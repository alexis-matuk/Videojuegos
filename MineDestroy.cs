using UnityEngine;
using System.Collections;

public class MineDestroy : MonoBehaviour {

	GameObject explosion;
	Aphelion aphelion;
	Sprite red;
	
	void Start()
	{
		explosion = Resources.Load<GameObject>("Prefabs/explosion");
		red = Resources.Load<Sprite>("Sprites/MineRed");
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
		Mine fleet = gameObject.GetComponent<Mine>();
		fleet.reduceHealthBy(fireBurning.getDamage());//reducir vida
		Destroy (fireBurning.gameObject);//destruir bala
		SpriteRenderer sprite = transform.parent.gameObject.GetComponent<SpriteRenderer>();
		sprite.color = new Color(1, 0, 0, 1);//cambiar de color a rojo
		transform.parent.parent.gameObject.GetComponent<MineFlicker>().changeColor();
		if(fleet.getHealth() <= 0)//si se destruye la nave
		{
			Instantiate (explosion, transform.position, transform.rotation);//instanciar explosión
			Destroy (fleet.transform.parent.parent.gameObject);
		}
	}
	
	//golpeado por láser
	//hace lo mismo que hitByFireBurningBullet, pero para el caso de láser
	void hitByLaser(laserFire laser)
	{
		Mine fleet = gameObject.GetComponent<Mine>();
		fleet.reduceHealthBy(laser.getDamage());
		SpriteRenderer sprite = transform.parent.gameObject.GetComponent<SpriteRenderer>();
		sprite.color = new Color(1, 0, 0, 1);
		transform.parent.parent.gameObject.GetComponent<MineFlicker>().changeColor();
		if(fleet.getHealth() <= 0)
		{

			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (fleet.transform.parent.parent.gameObject);
		}
	}
	
	//golpeado por onda
	//hace lo mismo que hitByFireBurningBullet, pero para el caso de onda
	void hitByWave(Wave wave)
	{
		Mine fleet = gameObject.GetComponent<Mine>();
		fleet.reduceHealthBy(wave.getDamage());
		SpriteRenderer sprite = transform.parent.gameObject.GetComponent<SpriteRenderer>();
		sprite.color = new Color(1, 0, 0, 1);
		transform.parent.parent.gameObject.GetComponent<MineFlicker>().changeColor();
		if(fleet.getHealth() <= 0)
		{
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (fleet.transform.parent.parent.gameObject);
		}
	}
	
	//golpeado por bala normal
	//hace lo mismo que hitByFireBurningBullet, pero para el caso de bala normal
	void hitByBullet(Bullet bala)
	{
		Mine fleet = gameObject.GetComponent<Mine>();
		fleet.reduceHealthBy(bala.getDamage());
		Destroy (bala.gameObject);
		SpriteRenderer sp = transform.parent.gameObject.GetComponent<SpriteRenderer>();
		sp.sprite = red;
		transform.parent.parent.gameObject.GetComponent<MineFlicker>().changeColor();
		if(fleet.getHealth() <= 0)
		{
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (fleet.transform.parent.parent.gameObject);
		}
	}
	
	
	//regresar animación de explosión
	public GameObject getExplosion()
	{
		return explosion;
	}
}
