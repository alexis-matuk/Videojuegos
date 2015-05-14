using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//clase que maneja las variables de Aphelion
public class Aphelion : MonoBehaviour {

/*Declaración de variables*/
	public int bulletDamage = 3;
	public int health = 30;
	int permanentHealth = 30;
	int permanentShield = 20;
	public int score = 0;
	public int shield = 20;
	int tempDamageUps = 0;
	float tempSpeedUps = 0;
	float moveSpeed = 500;
	float duration = 30;
	float permanentSpeed;
	Text Score;
	bool shieldCalled = false;
	bool shieldDrawn = false;
	bool shieldDone = true;
	GameObject sh;
	UnityEngine.UI.Image hpBar;
	UnityEngine.UI.Image shieldBar;
	GameObject tempS;
	
	Text hpText;
	Text shieldText;
	Text restartLabel;
	
	bool reset = false;
	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		Score = GameObject.Find("Score").GetComponent<Text>();
		permanentHealth = health;
		permanentShield =  shield;
		permanentSpeed = moveSpeed;
		hpText = GameObject.Find("hpText").GetComponent<Text>(); //referencia a texto
		restartLabel = GameObject.Find("Restart").GetComponent<Text>(); // referencia a texto
		shieldText = GameObject.Find("defenseText").GetComponent<Text>();//referencia a texto
		hpText.text = health.ToString();
		shieldText.text =  shield.ToString();
		hpBar = GameObject.FindGameObjectWithTag("Health").GetComponent<UnityEngine.UI.Image>();//barra de hp
		shieldBar = GameObject.FindGameObjectWithTag("Shield").GetComponent<UnityEngine.UI.Image>();//barra de shield
		hpBar.fillAmount = convertDamage(health, permanentHealth);
		shieldBar.fillAmount = convertDamage(shield,permanentShield);
		sh = Resources.Load<GameObject>("Prefabs/shield");
	}

	void OnLevelWasLoaded()
	{
		reset = false;
	}
	
	
	
	void Update()
	{
		if(!reset)
			resetHealth();
		drawTempShield();
	}
	
	void resetHealth()
	{
		if (Application.loadedLevel != 0) {
			health = 30;
			permanentHealth = health;
			shield = 20;
			permanentShield = shield;
			hpBar.fillAmount = 1;
			shieldBar.fillAmount = 1;
			hpText.text = health.ToString();
			shieldText.text =  shield.ToString();
			reset = true;
		}
	}
	
	//obtener daño
	public int getDamage()
	{
		return bulletDamage;
	}
	
	//obtener vida
	public int getHealth()
	{
		return health;
	}
	
	//reducir vida
	public void reduceHealthOrShield(int dmg)
	{
	
		if(!shieldCalled)//si no se tiene escudo temporal
		{
			if(dmg > shield && shield > 0)//en caso de que le hagan más daño del que puede soportar su escudo
			{
				int takeAway = dmg-shield;
				shield-=dmg-takeAway;
				shieldText.text = shield.ToString();
				shieldBar = GameObject.FindGameObjectWithTag("Shield").GetComponent<UnityEngine.UI.Image>();//barra de shield
				shieldBar.fillAmount -= convertDamage((dmg-takeAway), permanentShield);//reducir shield de barra
				health -= takeAway;
				hpText.text = health.ToString();//cambiar texto
				hpBar.fillAmount -= convertDamage(takeAway, permanentHealth);//reducir hp de barra
			}
			else if (shield > 0)//cuando sí tiene escudo
			{
				shield-=dmg;
				shieldText.text = shield.ToString();
				shieldBar.fillAmount -= convertDamage(dmg, permanentShield);//reducir shield de barra
			}
			else//cuando no tiene escudo
			{
				health -= dmg;
				hpText.text = health.ToString();//cambiar texto
				hpBar.fillAmount -= convertDamage(dmg, permanentHealth);//reducir hp de barra
			}
			if(health <= 0)//acabar juego
			{
				hpText.enabled = false;
				restartLabel.enabled = true;
				GameObject.FindGameObjectWithTag("Handler").GetComponent<RestartGame>().endGame();
				Time.timeScale = 0;
			}
		}
	}
	
	void drawTempShield()//dibujar y actualizar escudo temporal y posicion
	{
		if(shieldCalled)
		{
			if(!shieldDrawn)
			{
				tempS = (GameObject) Instantiate(sh, transform.FindChild("center").position, transform.FindChild("center").rotation);
				shieldDrawn = true;
			}
			else
			{
				tempS.transform.position = transform.FindChild("center").position;
				tempS.transform.rotation = transform.FindChild("center").rotation;
			}
		}
		
		if(shieldDone)//cuando se acaba el tiempo
		{
			shieldCalled = false;
			shieldDrawn = false;
			Destroy(tempS);
		}
	}
	
	IEnumerator waitForTempShield()//tiempo que dura el escudo
	{
		shieldDone = false;
		yield return new WaitForSeconds(duration);
		shieldDone = true;	
	}
	
	//agarrar hp pack
	public void increaseHealthBy(int hp)
	{
		if(health < permanentHealth)
		{
			if(health+hp < permanentHealth)//si no se va a pasar
			{
				health+=hp;//aumentar hp
				hpText.text = health.ToString();//cambiar texto
				hpBar.fillAmount += convertDamage(hp, permanentHealth);//aumentar shield de barra	
			}
			else//si se va a pasar
			{
				int actualHp = hp - ((health + hp)-permanentHealth);
				health += actualHp;
				hpText.text = health.ToString();//cambiar texto
				hpBar.fillAmount += convertDamage(actualHp, permanentHealth);//aumentar hp de barra
			}
		}
	}
	
	//agarrar shield pack
	public void increaseShieldBy(int sh)
	{
		if(shield < permanentShield)
		{
			if(shield+sh < permanentShield)//si no se va a pasar
			{
				shield+=sh;
				shieldText.text = shield.ToString();//cambiar texto
				shieldBar.fillAmount += convertDamage(sh, permanentShield);//aumentar shield de barra	
			}
			else//si se va a pasar
			{
				int actualShield = sh - ((shield + sh)-permanentShield);
				shield += actualShield;
				shieldText.text = shield.ToString();//cambiar texto
				shieldBar.fillAmount += convertDamage(actualShield, permanentShield);//aumentar shield de barra
			}
		}
	}
	
	public void increaseDamageBy(int dmg)
	{
		bulletDamage+=dmg;
		tempDamageUps+=dmg;
	}
	
	public void increaseSpeedBy(float spe)
	{
		moveSpeed+=spe;
		tempSpeedUps+=spe;
		gameObject.GetComponent<aphelionMovement>().updateSpeed();
	}
	
	public float getSpeed()
	{
		return moveSpeed;
	}
	
	//función para convertir el daño a la escala de la barra
	float convertDamage(int damage, int health)
	{	
		float dmg = (float) damage;
		float hp = (float) health;
		float conversion = (1/hp)*dmg;//relación entre hp y la barra
		return conversion;
	}
	
	public bool getShieldDone()
	{
		return shieldDone;
	}
	
	public void spawnShield()
	{
		shieldCalled = true;
		shieldDone = false;
		StartCoroutine(waitForTempShield());
	}
	
	public void updateScore()
	{
		Score.text = "Score: "+score;//actualizar texto
	}
	
	public float getInitialSpeed()
	{
		return permanentSpeed;
	}	
	
	//función utilizada en la barra de HP
	public int getInitialHealth()
	{
		return permanentHealth;
	}
	
	public int getInitialShield()
	{
		return permanentShield;
	}
	
	//incrementar score
	public void increaseScoreBy(int sc)
	{
		score+=sc;
	}
	
	public float getDuration()
	{
		return duration;
	}
	
	//obtener score
	public int getScore()
	{
		return score;
	}
}
