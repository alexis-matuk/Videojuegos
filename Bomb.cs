using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	 int damage = 3;
	 GameObject explosion;
	 
	void Start()
	{
		explosion = Resources.Load<GameObject>("Prefabs/explosion");
	}
	//obtener daño
	public int getDamage()
	{
		return damage;
	}
	
	public GameObject getExplosion()
	{
		return explosion;
	}
	
	
}
