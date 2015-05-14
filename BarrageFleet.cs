using UnityEngine;
using System.Collections;

public class BarrageFleet : MonoBehaviour {

	/*Declaración de variables*/
	public int damage = 3;
	public int health = 10;
	int score = 350;
	
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
