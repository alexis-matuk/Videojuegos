using UnityEngine;
using System.Collections;

//script para disparar NastyHarry
public class NastyHarryFire : MonoBehaviour {
/*Declaración de variables*/
	public GameObject bullet;
	public float minBulls;
	public float maxBulls;
	public float minAngle;
	public float maxAngle;
	float randomBullets;
	float randomAngle;
	bool spawned;
	int rbull;

	void Start () {
		randomBullets = Random.Range(minBulls,maxBulls);//instanciar un número random de balas
		rbull = (int) randomBullets;//pasarlo a int
	}
	
	void Update () {
		if(!spawned)//evitar problemas en el Update
		{
			for(int i = 0; i<rbull; i++)//instanciar dese una bala hasta rbull
			{
				randomAngle = Random.Range(minAngle,maxAngle);//ángulo al azar entre un rango
				GameObject bull = (GameObject) Instantiate(bullet,transform.position,transform.rotation);//instanciar bala
				bull.transform.Rotate (0,0,randomAngle);//cambiar su rotación
			}
			spawned = true;//cuando acabas de instanciar todas las balas dejas de poder instanciar
		}
	}
}
