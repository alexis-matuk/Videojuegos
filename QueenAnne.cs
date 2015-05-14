using UnityEngine;
using System.Collections;

public class QueenAnne : MonoBehaviour {
	
	int damage = 20;
	public int health = 10000;
	int score = 45000;
	int touchDamage = 3;
	
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

	public int getTouchDamage()
	{
		return touchDamage;
	}
}
