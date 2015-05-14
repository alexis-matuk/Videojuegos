using UnityEngine;
using System.Collections;

//Clase para el arma de onda
public class Wave : MonoBehaviour {

	int damage;
	
	//obtener daño
	public int getDamage()
	{
		damage = GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>().getDamage();
		return damage;
	}
	
	//establecer daño
	public void setDamage( int dmg)
	{
		damage = dmg;
	}
}
