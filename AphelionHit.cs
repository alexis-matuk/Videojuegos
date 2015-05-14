using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//clase que maneja los golpes que toma aphelion
public class AphelionHit : MonoBehaviour {
	
	private bool onCD = false;
	public float cdTime = 2f;
	bool shieldDone;
	
	void Start()
	{
		shieldDone = gameObject.GetComponent<Aphelion>().getShieldDone();//si tiene shield
	}
	
	//cuando entra un trigger
	void OnTriggerStay2D(Collider2D col)
	{
		shieldDone = gameObject.GetComponent<Aphelion>().getShieldDone();//si tiene shield
		EnemyBullet bull = col.GetComponent<EnemyBullet>();
		Aphelion aphelion = gameObject.GetComponent<Aphelion>();
		if(bull && !onCD)//si fue una bala enemiga y no está en cooldown
		{
			hitByBullet(bull, aphelion, col);
			if(shieldDone)
				gameObject.GetComponent<BulletFireScript>().resetBullet();//quitar power up de aphelion
		}
		
		StFleet fleet = col.GetComponent<StFleet>();
		StFleetDestroy exp = col.GetComponent<StFleetDestroy>();
		if(fleet && !onCD)//si fue un enemigo
		{
			hitByFleet(fleet, exp, aphelion, col);
			if(shieldDone)
				gameObject.GetComponent<BulletFireScript>().resetBullet();//quitar power up de aphelion
		}
		
		BarrageFleet barr = col.GetComponent<BarrageFleet>();
		BarrageFleetDestroy expbarr = col.GetComponent<BarrageFleetDestroy>();
		if(barr && !onCD)//si fue un enemigo
		{
			hitByBarrage(barr, expbarr, aphelion, col);
			if(shieldDone)
				gameObject.GetComponent<BulletFireScript>().resetBullet();//quitar power up de aphelion
		}
		
		CrossStream cross = col.GetComponent<CrossStream>();
		CrossStreamDestroy exCross = col.GetComponent<CrossStreamDestroy>();
		if(cross && !onCD)//si fue un enemigo
		{
			hitByCrossStream(cross, exCross, aphelion, col);
			if(shieldDone)
				gameObject.GetComponent<BulletFireScript>().resetBullet();//quitar power up de aphelion
		}
		
		WaveForm wave = col.GetComponent<WaveForm>();
		WaveFormDestroy expWave = col.GetComponent<WaveFormDestroy>();
		if(wave && !onCD)//si fue un enemigo
		{
			hitByWaveForm(wave, expWave, aphelion, col);
			if(shieldDone)
				gameObject.GetComponent<BulletFireScript>().resetBullet();//quitar power up de aphelion
		}
		
		TCreep creep = col.GetComponent<TCreep>();
		TCreepDestroy creepExp = col.GetComponent<TCreepDestroy>();
		if(creep && !onCD)//si fue un enemigo
		{
			hitByCreep(creep, creepExp, aphelion, col);
			if(shieldDone)
				gameObject.GetComponent<BulletFireScript>().resetBullet();//quitar power up de aphelion
		}
		
		ShootingStar star = col.GetComponent<ShootingStar>();
		ShootingStarDestroy starExp = col.GetComponent<ShootingStarDestroy>();
		if(star && !onCD)//si fue un enemigo
		{
			hitByStar(star, starExp, aphelion, col);
			if(shieldDone)
				gameObject.GetComponent<BulletFireScript>().resetBullet();//quitar power up de aphelion
		}
		
		HolePuncher punch = col.GetComponent<HolePuncher>();
		HolePuncherDestroy punchExp = col.GetComponent<HolePuncherDestroy>();
		if(punch && !onCD)//si fue un enemigo
		{
			hitByHolePuncher(punch, punchExp, aphelion, col);
			if(shieldDone)
				gameObject.GetComponent<BulletFireScript>().resetBullet();//quitar power up de aphelion
		}
		
		Smoke smoke = col.GetComponent<Smoke>();
		if(smoke && !onCD)//si fue un enemigo
		{
			hitBySmoke(smoke, aphelion, col);
			if(shieldDone)
				gameObject.GetComponent<BulletFireScript>().resetBullet();//quitar power up de aphelion
		}

		Expansive expansive = col.GetComponent<Expansive>();
		if(expansive && !onCD)//si fue un enemigo
		{
			hitByExpansive(expansive, aphelion, col);
			if(shieldDone)
				gameObject.GetComponent<BulletFireScript>().resetBullet();//quitar power up de aphelion
		}
		
		if(col.gameObject.name == "Kamikaze")
		{
			Kamikaze kam = col.transform.FindChild("ActualCollider").gameObject.GetComponent<Kamikaze>();
			KamikazeDestroy kamExp = col.transform.FindChild("ActualCollider").gameObject.GetComponent<KamikazeDestroy>();
			if(kam && !onCD)//si fue un enemigo
			{
				hitByKamikaze(kam, kamExp, aphelion, col);
				if(shieldDone)
					gameObject.GetComponent<BulletFireScript>().resetBullet();//quitar power up de aphelion
			}
		}
		
		if(col.gameObject.name == "Mine1")
		{
			Mine mine = col.transform.FindChild("ActualCollider").gameObject.GetComponent<Mine>();
			MineDestroy mineExp = col.transform.FindChild("ActualCollider").gameObject.GetComponent<MineDestroy>();
			if(mine && !onCD)//si fue un enemigo
			{
				hitByMine(mine, mineExp, aphelion, col);
				if(shieldDone)
					gameObject.GetComponent<BulletFireScript>().resetBullet();//quitar power up de aphelion
			}
		}
	}
	
	//golpeado por bala
	void hitByBullet(EnemyBullet bull, Aphelion aphelion, Collider2D col)
	{
//		UnityEngine.UI.Image hpBar = GameObject.FindGameObjectWithTag("Health").GetComponent<UnityEngine.UI.Image>();//barra de hp
//		hpBar.fillAmount -= convertDamage(bull.getDamage(), aphelion.getInitialHealth());//reducir hp de barra
		aphelion.reduceHealthOrShield(bull.getDamage());//reducir hp de aphelion
		SpriteRenderer sprite =  gameObject.GetComponent<SpriteRenderer>();
		if(shieldDone)
		{
			sprite.color = new Color(1f,1f,1f,.5f);//cambiar sprite cuando lo golpean
		}
		StartCoroutine(coolDownDmg(sprite));//funcion de cooldown
		Destroy (col.gameObject);//destruir la bala
	}
	
	void hitBySmoke(Smoke fleet, Aphelion aphelion, Collider2D col)
	{
		aphelion.reduceHealthOrShield(fleet.getDamage());//reducir hp de aphelion
		SpriteRenderer sprite =  gameObject.GetComponent<SpriteRenderer>();
		if(shieldDone)
		{
			sprite.color = new Color(1f,1f,1f,.5f);//cambiar sprite cuando lo golpean
		}
		StartCoroutine(coolDownDmg(sprite));//funcion de cooldown
		Destroy (col.gameObject);//destruir la bala
	}
	
	//golpeado por enemigo
	void hitByFleet(StFleet fleet, StFleetDestroy exp, Aphelion aphelion, Collider2D col)
	{
		aphelion.reduceHealthOrShield(fleet.getDamage());//reducir hp de aphelion
		SpriteRenderer sprite =  gameObject.GetComponent<SpriteRenderer>();
		if(shieldDone)
		{
			sprite.color = new Color(1f,1f,1f,.5f);//cambiar sprite cuando lo golpean
		}
		StartCoroutine(coolDownDmg(sprite));//funcion de cooldown
		gameObject.GetComponent<Aphelion>().increaseScoreBy(fleet.getScore());//aumentar score de aphelion
		aphelion.updateScore();
		Destroy (col.gameObject);//destruir la bala
		Instantiate (exp.getExplosion(), fleet.transform.position, fleet.transform.rotation);//instanciar explosión
	}


	void hitByExpansive(Expansive expansive, Aphelion aphelion, Collider2D col)
	{
		aphelion.reduceHealthOrShield(expansive.getDamage());//reducir hp de aphelion
		SpriteRenderer sprite =  gameObject.GetComponent<SpriteRenderer>();
		if(shieldDone)
		{
			sprite.color = new Color(1f,1f,1f,.5f);//cambiar sprite cuando lo golpean
		}
		StartCoroutine(coolDownDmg(sprite));//funcion de cooldown
		//gameObject.GetComponent<Aphelion>().increaseScoreBy(expansive.getScore());//aumentar score de aphelion
		//aphelion.updateScore();
		//Destroy (col.gameObject);//destruir la bala
		//Instantiate (exp.getExplosion(), fleet.transform.position, fleet.transform.rotation);//instanciar explosión
	}

	void hitByBarrage(BarrageFleet fleet, BarrageFleetDestroy exp, Aphelion aphelion, Collider2D col)
	{
		aphelion.reduceHealthOrShield(fleet.getDamage());//reducir hp de aphelion
		SpriteRenderer sprite =  gameObject.GetComponent<SpriteRenderer>();
		if(shieldDone)
		{
			sprite.color = new Color(1f,1f,1f,.5f);//cambiar sprite cuando lo golpean	
		}
		StartCoroutine(coolDownDmg(sprite));//funcion de cooldown
		gameObject.GetComponent<Aphelion>().increaseScoreBy(fleet.getScore());//aumentar score de aphelion
		aphelion.updateScore();
		Destroy (col.gameObject);//destruir la bala
		Instantiate (exp.getExplosion(), fleet.transform.position, fleet.transform.rotation);//instanciar explosión
	}
	
	void hitByCrossStream(CrossStream fleet, CrossStreamDestroy exp, Aphelion aphelion, Collider2D col)
	{
		aphelion.reduceHealthOrShield(fleet.getDamage());//reducir hp de aphelion
		SpriteRenderer sprite =  gameObject.GetComponent<SpriteRenderer>();
		if(shieldDone)
		{
			sprite.color = new Color(1f,1f,1f,.5f);//cambiar sprite cuando lo golpean
		}
		StartCoroutine(coolDownDmg(sprite));//funcion de cooldown
		gameObject.GetComponent<Aphelion>().increaseScoreBy(fleet.getScore());//aumentar score de aphelion
		aphelion.updateScore();
		Destroy (col.gameObject);//destruir la bala
		Instantiate (exp.getExplosion(), fleet.transform.position, fleet.transform.rotation);//instanciar explosión
	}
	
	void hitByWaveForm(WaveForm fleet, WaveFormDestroy exp, Aphelion aphelion, Collider2D col)
	{
		aphelion.reduceHealthOrShield(fleet.getDamage());//reducir hp de aphelion
		SpriteRenderer sprite =  gameObject.GetComponent<SpriteRenderer>();
		if(shieldDone)
		{
			sprite.color = new Color(1f,1f,1f,.5f);//cambiar sprite cuando lo golpean
		}
		StartCoroutine(coolDownDmg(sprite));//funcion de cooldown
		gameObject.GetComponent<Aphelion>().increaseScoreBy(fleet.getScore());//aumentar score de aphelion
		aphelion.updateScore();
		Destroy (col.gameObject);//destruir la bala
		Instantiate (exp.getExplosion(), fleet.transform.position, fleet.transform.rotation);//instanciar explosión
	}
	
	void hitByStar(ShootingStar fleet, ShootingStarDestroy exp, Aphelion aphelion, Collider2D col)
	{
		aphelion.reduceHealthOrShield(fleet.getDamage());//reducir hp de aphelion
		SpriteRenderer sprite =  gameObject.GetComponent<SpriteRenderer>();
		if(shieldDone)
		{
			sprite.color = new Color(1f,1f,1f,.5f);//cambiar sprite cuando lo golpean
		}
		StartCoroutine(coolDownDmg(sprite));//funcion de cooldown
		gameObject.GetComponent<Aphelion>().increaseScoreBy(fleet.getScore());//aumentar score de aphelion
		aphelion.updateScore();
		Destroy (col.gameObject);//destruir la bala
		Instantiate (exp.getExplosion(), fleet.transform.position, fleet.transform.rotation);//instanciar explosión
	}
	
	
	void hitByCreep(TCreep fleet, TCreepDestroy exp, Aphelion aphelion, Collider2D col)
	{
		aphelion.reduceHealthOrShield(fleet.getDamage());//reducir hp de aphelion
		SpriteRenderer sprite =  gameObject.GetComponent<SpriteRenderer>();
		if(shieldDone)
		{
			sprite.color = new Color(1f,1f,1f,.5f);//cambiar sprite cuando lo golpean
		}
		StartCoroutine(coolDownDmg(sprite));//funcion de cooldown
		gameObject.GetComponent<Aphelion>().increaseScoreBy(fleet.getScore());//aumentar score de aphelion
		aphelion.updateScore();
		Destroy (col.gameObject);//destruir la bala
		Instantiate (exp.getExplosion(), fleet.transform.position, fleet.transform.rotation);//instanciar explosión
	}
	
	void hitByHolePuncher(HolePuncher fleet, HolePuncherDestroy exp, Aphelion aphelion, Collider2D col)
	{
		aphelion.reduceHealthOrShield(fleet.getDamage());//reducir hp de aphelion
		SpriteRenderer sprite =  gameObject.GetComponent<SpriteRenderer>();
		if(shieldDone)
		{
			sprite.color = new Color(1f,1f,1f,.5f);//cambiar sprite cuando lo golpean
		}
		StartCoroutine(coolDownDmg(sprite));//funcion de cooldown
		gameObject.GetComponent<Aphelion>().increaseScoreBy(fleet.getScore());//aumentar score de aphelion
		aphelion.updateScore();
		Destroy (col.gameObject);//destruir la bala
		Instantiate (exp.getExplosion(), fleet.transform.position, fleet.transform.rotation);//instanciar explosión
	}
	
	void hitByKamikaze(Kamikaze fleet, KamikazeDestroy exp, Aphelion aphelion, Collider2D col)
	{
		aphelion.reduceHealthOrShield(fleet.getDamage());//reducir hp de aphelion
		SpriteRenderer sprite =  gameObject.GetComponent<SpriteRenderer>();
		if(shieldDone)
		{
			sprite.color = new Color(1f,1f,1f,.5f);//cambiar sprite cuando lo golpean
		}
		StartCoroutine(coolDownDmg(sprite));//funcion de cooldown
		gameObject.GetComponent<Aphelion>().increaseScoreBy(fleet.getScore());//aumentar score de aphelion
		aphelion.updateScore();
		Destroy (col.transform.parent.gameObject);//destruir la bala
		Instantiate (exp.getExplosion(), fleet.transform.position, fleet.transform.rotation);//instanciar explosión
	}
	
	void hitByMine(Mine fleet, MineDestroy exp, Aphelion aphelion, Collider2D col)
	{
		aphelion.reduceHealthOrShield(fleet.getDamage());//reducir hp de aphelion
		SpriteRenderer sprite =  gameObject.GetComponent<SpriteRenderer>();
		if(shieldDone)
		{
			sprite.color = new Color(1f,1f,1f,.5f);//cambiar sprite cuando lo golpean
		}
		StartCoroutine(coolDownDmg(sprite));//funcion de cooldown
		Destroy (col.transform.parent.gameObject);//destruir la bala
		Instantiate (exp.getExplosion(), fleet.transform.position, fleet.transform.rotation);//instanciar explosión
	}

	void hitByMine(Expansive onda, Aphelion aphelion, Collider2D col)
	{
		aphelion.reduceHealthOrShield(onda.getDamage());//reducir hp de aphelion
		SpriteRenderer sprite =  gameObject.GetComponent<SpriteRenderer>();
		if(shieldDone)
		{
			sprite.color = new Color(1f,1f,1f,.5f);//cambiar sprite cuando lo golpean
		}
		StartCoroutine(coolDownDmg(sprite));//funcion de cooldown
		Destroy (col.transform.parent.gameObject);//destruir la bala
		// Instantiate (exp.getExplosion(), fleet.transform.position, fleet.transform.rotation);//instanciar explosión
	}
	
	//función de cooldown. Cuando se está en cooldown no te pueden golpear
	IEnumerator coolDownDmg(SpriteRenderer sprite)
	{
		onCD = true;
		yield return new WaitForSeconds(cdTime);//espera cdTime segundos
		sprite.color = new Color(1f,1f,1f,1f);//regresar color al original
		onCD = false;
	}
}
