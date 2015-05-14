using UnityEngine;
using System.Collections;

public class CrossStream : MonoBehaviour {

	int damage = 2;
	int health = 10;
	int score = 300;
	
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
	
	//obtener score que otorga al ser destruido
	public int getScore()
	{
		return score;
	}
}
