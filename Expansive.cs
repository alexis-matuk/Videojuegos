using UnityEngine;
using System.Collections;

public class Expansive : MonoBehaviour {

	public int damage = 5;
	public int health = 10;
	
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
	public void setDamage( int dmg)
	{
		damage = dmg;
	}
}
