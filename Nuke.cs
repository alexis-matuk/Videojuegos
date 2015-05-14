using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Nuke : MonoBehaviour {

	GameObject explosion;
	void OnTriggerEnter2D(Collider2D col)
	{
		Aphelion aphelion = col.gameObject.GetComponent<Aphelion>();
		if(aphelion)
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			explosion = Resources.Load<GameObject>("Prefabs/explosion");
			if(enemies.Length>0)
			{
				for(int i=0; i<enemies.Length; i++)
				{
					StFleet fleet = enemies[i].GetComponent<StFleet>();
					BarrageAI barr = enemies[i].GetComponent<BarrageAI>();
					CrossStream cross = enemies[i].GetComponent<CrossStream>();
					WaveForm wave = enemies[i].GetComponent<WaveForm>();
					TCreep creep = enemies[i].GetComponent<TCreep>();
					ShootingStar star = enemies[i].GetComponent<ShootingStar>();
					HolePuncher punch = enemies[i].GetComponent<HolePuncher>();
					KamikazeFlicker kam = enemies[i].GetComponent<KamikazeFlicker>();
					EliteBomber eliteBomber = enemies[i].GetComponent<EliteBomber>();
					Smoke smoke = enemies[i].GetComponent<Smoke>();
					
					if(fleet){
						aphelion.increaseScoreBy(fleet.getScore());
						Destroy(enemies[i]);
						Instantiate(explosion, enemies[i].transform.position, enemies[i].transform.rotation);
					}
					else if(barr){
						foreach(Transform child in enemies[i].transform)
						{
							Destroy(child.gameObject);
							Instantiate(explosion, child.transform.position, child.transform.rotation);
							aphelion.increaseScoreBy(child.gameObject.GetComponent<BarrageFleet>().getScore());
						}
					}
					else if(cross)
					{
						aphelion.increaseScoreBy(cross.getScore());
						Destroy(enemies[i]);
						Instantiate(explosion, enemies[i].transform.position, enemies[i].transform.rotation);
					}
					else if(wave)
					{
						aphelion.increaseScoreBy(wave.getScore());
						Destroy(enemies[i]);
						Instantiate(explosion, enemies[i].transform.position, enemies[i].transform.rotation);
					}
					else if(creep)
					{
						aphelion.increaseScoreBy(creep.getScore());
						Destroy(enemies[i]);
						Instantiate(explosion, enemies[i].transform.position, enemies[i].transform.rotation);
					}
					else if(star)
					{
						aphelion.increaseScoreBy(star.getScore());
						Destroy(enemies[i]);
						Instantiate(explosion, enemies[i].transform.position, enemies[i].transform.rotation);
					}
					else if(punch)
					{
						aphelion.increaseScoreBy(punch.getScore());
						Destroy(enemies[i]);
						Instantiate(explosion, enemies[i].transform.position, enemies[i].transform.rotation);
					}
					else if(kam)
					{
						aphelion.increaseScoreBy(kam.gameObject.transform.FindChild("Kamikaze").FindChild("ActualCollider").GetComponent<Kamikaze>().getScore());
						Destroy(enemies[i]);
						Instantiate(explosion, enemies[i].transform.position, enemies[i].transform.rotation);
					}
					else if(eliteBomber)
					{
						eliteBomber.reduceHealthBy(eliteBomber.getInitialHealth()/8);
						Instantiate(explosion, enemies[i].transform.position, enemies[i].transform.rotation);
					}
					else if(smoke)
					{
						Destroy(enemies[i]);
					}
				}
			}
			Destroy(gameObject);
			aphelion.updateScore();
		}
	}
}
