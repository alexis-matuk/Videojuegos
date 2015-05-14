using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//script que maneja el spawn de los powerUps
public class spawnPowerUp : MonoBehaviour {
/*Declaración de variables*/
	//public GameObject[] powerUps;
	public float waitTime;
	public float spawnRateMin;
	public float spawnRateMax;
	bool allowSpawn = true;
	public GameObject[] spawners;
	List<GameObject> powerUps;
	
	void Start () {
		powerUps = new List<GameObject>();
		spawners = GameObject.FindGameObjectsWithTag("powerUpSpawner");//encontrar todos los spawners posibles
		powerUps.Add(Resources.Load<GameObject>("Prefabs/XW"));
		powerUps.Add(Resources.Load<GameObject>("Prefabs/wave_icon"));
		powerUps.Add(Resources.Load<GameObject>("Prefabs/laserPowerUp"));
		powerUps.Add(Resources.Load<GameObject>("Prefabs/fireBurningIcon"));
		powerUps.Add(Resources.Load<GameObject>("Prefabs/nastyHarryPower"));
		
	}
	
	void Update()
	{
		if(allowSpawn && spawners.Length > 0 && powerUps.Count > 0)
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
		int power = Random.Range(0,powerUps.Count);
		int spawn = Random.Range(0,spawners.Length);
		Instantiate(powerUps[power], spawners[spawn].transform.position, Quaternion.Euler (0,0,0));//instanciar un powerUp random en una posicion random de las posibles
	}
}
