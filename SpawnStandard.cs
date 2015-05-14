using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//script para instanciar StFleets
public class SpawnStandard : MonoBehaviour {
/*Declaración de Variables*/
	//public GameObject[] enemies;
	public float waitTime;
	public float spawnRateMin;
	public float spawnRateMax;
	List<GameObject> enemies;
	int range = 200;//rango que tiene el spawner. si Aphelion está dentro de este rango no se crean los enemigos
	void Start () {
		enemies = new List<GameObject>();
		enemies.Add(Resources.Load<GameObject>("Prefabs/st_fleet_2"));
		enemies.Add(Resources.Load<GameObject>("Prefabs/Barrage"));
		enemies.Add(Resources.Load<GameObject>("Prefabs/crossStream"));
		enemies.Add(Resources.Load<GameObject>("Prefabs/waveForm"));
		enemies.Add(Resources.Load<GameObject>("Prefabs/TCreep"));
		enemies.Add(Resources.Load<GameObject>("Prefabs/shootingStar"));
		enemies.Add(Resources.Load<GameObject>("Prefabs/HolePuncher"));
		enemies.Add(Resources.Load<GameObject>("Prefabs/Kam"));
		InvokeRepeating("Spawn", waitTime, Random.Range(spawnRateMin, spawnRateMax));
	}
	
	//instanciar enemigo
	void Spawn()
	{
		int enemy = Random.Range(0,enemies.Count);//elegir un enemigo de la lista de enemigos
		enemy = selectEnemy(enemies[enemy].gameObject.name);
		Aphelion aphelion = GameObject.FindWithTag("Player").gameObject.GetComponent<Aphelion>();
		if(Mathf.Abs(aphelion.transform.position.x -  transform.position.x)>=range)
		{
			if(Mathf.Abs(aphelion.transform.position.y -  transform.position.y)>=range)
			{
				Instantiate(enemies[enemy], transform.position, Quaternion.Euler (0,0,0));//instanciar enemigo si Aphelion no está dentro del rango
			}
		}
	}
	
	int selectEnemy(string enem)
	{
		float chance = Random.Range(0,100);
		if(chance <= 10 && enem == "Barrage")
		{
			return 1;
		}
		else if(chance <= 20 && enem == "waveForm")
		{
			return 3;
		}
		else if(chance <= 25 && enem == "HolePuncher")
		{
			return 6;
		}
		else if(chance <= 30 && enem == "crossStream")
		{
			return 2;
		}
		else if(chance <= 35 && enem == "shootingStar")
		{
			return 5;
		}
		else if(chance <= 45 && enem == "TCreep")
		{
			return 4;
		}
		else if (chance <= 50 && enem == "Kam")
		{
			return 7;
		}
		{
			return 0;
		}
	}	
}
