using UnityEngine;
using System.Collections;

public class EliteBomberAI : MonoBehaviour {

	bool waiting = false;
	GameObject bomb;
	GameObject eliteBomb;
	GameObject kam;
	float waitTime = 5f;
	bool spawnedBombs = false;
	bool spawnedKams = false;
	// Use this for initialization
	void Start () {
		bomb = Resources.Load<GameObject>("Prefabs/bomb");
		eliteBomb = Resources.Load<GameObject>("Prefabs/eliteBomb");
		kam = Resources.Load<GameObject>("Prefabs/Kam");
	}
	
	// Update is called once per frame
	void Update () {
		if(!waiting)
		{
			StartCoroutine(attack());
		}
	}
	
	IEnumerator attack()
	{
		waiting = true;
		chooseAttack();
		spawnedKams = false;
		spawnedBombs = false;
		yield return new WaitForSeconds(waitTime);
		waiting = false;
	}
	
	void chooseAttack()
	{
		int att = Random.Range(1,101);
		if(att < 35){
			spawnKams();
		}
		else if(att < 40)
		{
			fireMissile();
		}
		else if(att < 100)
		{
			fireBombs();
		}
	}
	
	void fireBombs()
	{
		if(!spawnedBombs)
		{
			for(int i = 0; i < 5; i++)
			{
				Vector3 pos = new Vector3(Random.Range(-800,800), Random.Range(-500,500),412);
				Instantiate(bomb, pos, Quaternion.Euler(0,0,Random.Range(0,360)));
			}
			spawnedBombs = true;
		}
	}
	
	void fireMissile()
	{
		Instantiate(eliteBomb, transform.FindChild("tip").position, transform.FindChild("tip").rotation);
	}
	
	void spawnKams()
	{
		int amount = Random.Range(1,6);
		if(!spawnedKams)
		{
			for(int i = 0; i< amount; i++)
			{
				GameObject k = (GameObject) Instantiate(kam, new Vector3(transform.position.x+Random.Range(-100,100),transform.position.y+Random.Range(-100,100),412), Quaternion.Euler(0,0,transform.rotation.z+Random.Range(0,360)));
				k.gameObject.GetComponent<KamikazeFlicker>().setExtraSpeed(1000f);
			}
			spawnedKams = true;
		}
	}
}
