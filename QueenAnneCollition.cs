using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QueenAnneCollition : MonoBehaviour {

	GameObject explosion;
	Aphelion aphelion;
	bool waitingDmg = false;
	bool waitingDmgWave = false;
	Image hpBar;
	Text n;
	
	void Start()
	{
		aphelion = GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>();//referencia a aphelion
		explosion = Resources.Load<GameObject>("Prefabs/explosion");
		hpBar = GameObject.Find("bossHp").GetComponent<Image>();
		n = GameObject.Find("bossName").GetComponent<Text>();
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
		QueenAnne queenAnne = gameObject.GetComponent<QueenAnne>();
		queenAnne.reduceHealthBy(fireBurning.getDamage());//reducir vida
		Destroy (fireBurning.gameObject);//destruir bala
		SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
		sprite.color = new Color(1, 0, 0, 1);//cambiar de color a rojo
		StartCoroutine(retint (sprite));//corrutina para regresar a color normal
		if(queenAnne.getHealth() <= 0)//si se destruye la nave
		{
			hpBar.enabled = false;
			n.text = "";
			n.enabled = false;
			
			aphelion.increaseScoreBy(queenAnne.getScore());//aumentar score
			aphelion.updateScore();
			Instantiate (explosion, transform.position, transform.rotation);//instanciar explosión
			Destroy (queenAnne.gameObject);//destruir nave
		}
	}
	
	//golpeado por láser
	//hace lo mismo que hitByFireBurningBullet, pero para el caso de láser
	void hitByLaser(laserFire laser)
	{
		QueenAnne queenAnne = gameObject.GetComponent<QueenAnne>();
		if(!waitingDmg)
		{
			StartCoroutine(applyDamage(queenAnne, laser));
			SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
			sprite.color = new Color(1, 0, 0, 1);
			StartCoroutine(retint (sprite));
		}
		if(queenAnne.getHealth() <= 0)
		{
			hpBar.enabled = false;
			n.text = "";
			n.enabled = false;
			
			aphelion.increaseScoreBy(queenAnne.getScore());
			aphelion.updateScore();
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (queenAnne.gameObject);
		}
	}
	
	//golpeado por onda
	//hace lo mismo que hitByFireBurningBullet, pero para el caso de onda
	void hitByWave(Wave wave)
	{
		QueenAnne queenAnne = gameObject.GetComponent<QueenAnne>();		
		if(!waitingDmgWave)
		{
			StartCoroutine(applyDamageWave(queenAnne, wave));
			SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
			sprite.color = new Color(1, 0, 0, 1);
			StartCoroutine(retint (sprite));
		}
		if(queenAnne.getHealth() <= 0)
		{
			hpBar.enabled = false;
			n.text = "";
			n.enabled = false;
			
			aphelion.increaseScoreBy(queenAnne.getScore());
			aphelion.updateScore();
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (queenAnne.gameObject);
		}
	}
	
	//golpeado por bala normal
	//hace lo mismo que hitByFireBurningBullet, pero para el caso de bala normal
	void hitByBullet(Bullet bala)
	{
		QueenAnne queenAnne = gameObject.GetComponent<QueenAnne>();
		queenAnne.reduceHealthBy(bala.getDamage());
		Destroy (bala.gameObject);
		SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
		sprite.color = new Color(1, 0, 0, 1);
		StartCoroutine(retint (sprite));
		if(queenAnne.getHealth() <= 0)
		{
			hpBar.enabled = false;
			n.text = "";
			n.enabled = false;
			
			aphelion.increaseScoreBy(queenAnne.getScore());
			aphelion.updateScore();
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (queenAnne.gameObject);
		}
	}
	
	IEnumerator applyDamage(QueenAnne fleet, laserFire laser)
	{
		waitingDmg = true;
		fleet.reduceHealthBy(laser.getDamage());
		yield return new WaitForSeconds(0.3f);
		waitingDmg = false;
	}
	
	IEnumerator applyDamageWave(QueenAnne fleet, Wave wave)
	{
		waitingDmgWave = true;
		fleet.reduceHealthBy(wave.getDamage());
		yield return new WaitForSeconds(0.1f);
		waitingDmgWave = false;
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
