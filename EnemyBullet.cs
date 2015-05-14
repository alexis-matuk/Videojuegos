using UnityEngine;
using System.Collections;

//clase con las variables de la bala enemiga
public class EnemyBullet : MonoBehaviour {
/*Declaracion de variables*/
	int damage = 0;
	GameObject fleet;
	
	void Start()
	{
	//referncia al daño de StFleet
//		fleet = (GameObject) Resources.Load("Prefabs/st_fleet_2");
//		damage = fleet.GetComponent<StFleet>().getDamage();
	}	
	
	//obtener daño
	public int getDamage()
	{
		return damage;
	}
	
	//establecer daño
	public void setDamage( int dmg)
	{
		damage = dmg;
	}

}
