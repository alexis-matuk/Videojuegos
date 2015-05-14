using UnityEngine;
using System.Collections;

//clase Bala de Aphelion
public class Bullet : MonoBehaviour {
	int damage;

	//obtener daño de la bala
	public int getDamage()
	{
		damage = GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>().getDamage();
		return damage;
	}
	
	//establecer daño de la bala
	public void setDamage( int dmg)
	{
		damage = dmg;
	}
}
