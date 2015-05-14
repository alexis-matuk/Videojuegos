using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	int damage = 3;
	int health = 8;
	
	//obtener daño
	public int getDamage()
	{
		return damage;
	}
	
	//Obtener vida
	public int getHealth()
	{
		return health;
	}
	
	//reducir vida
	public void reduceHealthBy(int dmg)
	{
		health-=dmg;	
	}
}
