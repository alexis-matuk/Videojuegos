using UnityEngine;
using System.Collections;

public class EliteMissile : MonoBehaviour {

	int damage = 0;
	GameObject EliteBomber;
	GameObject explosion;
	
	void Start()
	{
		EliteBomber = Resources.Load<GameObject>("Prefabs/EliteBomber");
		explosion = Resources.Load<GameObject>("Prefabs/explosion");
		damage = EliteBomber.GetComponent<EliteBomber>().getMissileDamage();
	}	
	
	//obtener daño
	public int getDamage()
	{
		return damage;
	}
	
	//establecer daño
	public void setDamage( int dmg)
	{
		damage = dmg;
	}
	
	public GameObject getExplosion()
	{
		return explosion;
	}
}
