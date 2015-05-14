using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {

	int damage;
	TCreep creep;
	
	void Start()
	{
		creep = Resources.Load<GameObject>("Prefabs/TCreep").GetComponent<TCreep>();
		damage = creep.getDamage();
	}
	
	//obtener daño
	public int getDamage()
	{
		
		return damage;
	}

}
