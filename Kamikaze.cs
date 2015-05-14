using UnityEngine;
using System.Collections;

public class Kamikaze : MonoBehaviour {

	 int damage = 5;
	 int health = 8;
	 int score = 700;
	
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
