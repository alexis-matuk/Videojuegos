using UnityEngine;
using System.Collections;

public class HpPack : MonoBehaviour {

	int hp;
	
	public int getHp()
	{
		float percentageHp = GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>().getInitialHealth() * 0.15f;
		hp = (int) Mathf.Ceil(percentageHp);
		return hp;
	}
}
