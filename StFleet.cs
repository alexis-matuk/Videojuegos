using UnityEngine;
using System.Collections;

//clase StFleet
public class StFleet : MonoBehaviour {
/*Declaración de variables*/
	public int damage = 3;
	public int health = 10;
	public int score = 100;
	
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
