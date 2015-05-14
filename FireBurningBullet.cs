using UnityEngine;
using System.Collections;

//clase de bala para fireBurning
public class FireBurningBullet : MonoBehaviour {

	int damage;
	
	void Start()
	{
		damage = GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>().getDamage();//daño de jugador
	}
	
	//obtener el daño de la bala modificada
	public int getDamage()
	{
		float dmg = (float) damage * 1.7f;//daño *1.7
		int returnedDamage = (int)Mathf.Ceil(dmg);//redondear hacia arriba
		return returnedDamage;
	}
	
	public void setDamage( int dmg)
	{
		damage = dmg;
	}
}
