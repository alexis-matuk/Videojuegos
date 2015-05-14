using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QueenAnne : MonoBehaviour {
	
	int damage = 20;
	int health = 1000;
	int initialHealth;
	int score = 45000;
	int touchDamage = 3;
	Image hpBar;
	Text n;
	
	void Start()
	{
		initialHealth = health;
		hpBar = GameObject.Find("bossHp").GetComponent<Image>();
		n = GameObject.Find("bossName").GetComponent<Text>();
		n.text = "Queen Anne";
		hpBar.enabled = true;
		n.enabled = true;
	}	
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
		hpBar.fillAmount-=convertDamage(dmg, initialHealth);
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
	
	public int getInitialHealth()
	{
		return initialHealth;
	}
	
	float convertDamage(int damage, int health)
	{	
		float dmg = (float) damage;
		float hp = (float) health;
		float conversion = (1/hp)*dmg;//relación entre hp y la barra
		return conversion;
	}
}
