using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EliteBomber : MonoBehaviour {

	 int contactDamage = 5;
	 int missileDamage = 4;
	 int health = 1000;
	 int score = 10000;
	 int initialHealth;
	 Image hpBar;
	 Text n;
		
	 void Start()
	 {
		initialHealth = health;
		hpBar = GameObject.Find("bossHp").GetComponent<Image>();
		n = GameObject.Find("bossName").GetComponent<Text>();
		n.text = "Elite Bomber";
		hpBar.enabled = true;
		n.enabled = true;
	 }	
	
	//obtener daño
	public int getContactDamage()
	{
		return contactDamage;
	}
	
	public int getMissileDamage()
	{
		return missileDamage;
	}	
	
	//Obtener vida
	public int getHealth()
	{
		return health;
	}
	
	public int getInitialHealth()
	{
		return initialHealth;
	}
	
	//reducir vida
	public void reduceHealthBy(int dmg)
	{
		health-=dmg;	
		hpBar.fillAmount-=convertDamage(dmg, initialHealth);	
	}
	
	//obtener score que otorga al ser destruido
	public int getScore()
	{
		return score;
	}
	
	float convertDamage(int damage, int health)
	{	
		float dmg = (float) damage;
		float hp = (float) health;
		float conversion = (1/hp)*dmg;//relación entre hp y la barra
		return conversion;
	}
}
