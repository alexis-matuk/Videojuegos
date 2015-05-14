using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConsumableSpawner : MonoBehaviour {

	//public GameObject[] consumables;
	public float waitTime;
	public float spawnRateMin;
	public float spawnRateMax;
	bool allowSpawn = true;
	public GameObject[] spawners;
	List<GameObject> consumables;
	
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag("consumableSpawner");//encontrar todos los spawners posibles
		consumables = new List<GameObject>();
		consumables.Add(Resources.Load<GameObject>("Prefabs/hpPack"));
		consumables.Add(Resources.Load<GameObject>("Prefabs/shieldPack"));
		consumables.Add(Resources.Load<GameObject>("Prefabs/damageUp"));
		consumables.Add(Resources.Load<GameObject>("Prefabs/speedUp"));
		consumables.Add(Resources.Load<GameObject>("Prefabs/Nuke"));
		consumables.Add(Resources.Load<GameObject>("Prefabs/tempShield"));
	}
	
	void Update()
	{
		if(allowSpawn && spawners.Length > 0 && consumables.Count > 0)
		{
			StartCoroutine(sp());//corrutina de spawn
		}
	}	
	
	//spawnear powerUp
	IEnumerator sp()
	{
		allowSpawn = false;
		yield return new WaitForSeconds(Random.Range (spawnRateMin, spawnRateMax));//esperar un tiempo random antes de instanciar otro powerUp
		spawnPower ();
		allowSpawn = true;
	}
	
	//instanciar powerUp
	void spawnPower()
	{
		int rand = Random.Range(0,100);
		int power = getPower (rand);
		//int power = Random.Range(0,consumables.Length);
		int spawn = Random.Range(0,spawners.Length);
		Instantiate(consumables[power], spawners[spawn].transform.position, Quaternion.Euler (0,0,0));//instanciar un powerUp random en una posicion random de las posibles
	}
	
	int getPower(int rand)
	{
		if(rand <= 15)
		{
			if(Random.Range(0,100) >= 50)
			{
				return 2;//damage up
			}
			else
			{
				return 4;//nuke
			}
		}
		else if(rand <= 20)
		{
			return 5;//temp shield
		}
		else if(rand <= 25)
		{
			return 3;//speedUp
		}
		else if (rand <= 50)
		{
			return 1;//shiled pack
		}
		else
		{
			return 0;
		}
	}
}
