using UnityEngine;
using System.Collections;

public class QueenAnneSpawnMine : MonoBehaviour {
	public GameObject Enemy; 
	float coolDown=0;
	public float spawnDelay=2f;
	public int cont=0;
	
	// Use this for initialization
	void Start () {
	

	
	}
	
	// Update is called once per frame
	void Update () {

		if (cont < 3) {
			spawnEnemy ();
		} else if (cont == 3) {
			cont = 0;
			gameObject.GetComponent<QueenAnneAI>().setInactive(3);
		}
		
	}
	
	void spawnEnemy()
	{
		coolDown -= Time.deltaTime;
		if (coolDown <= 0) {
			coolDown = spawnDelay;
			Vector3 offset = transform.rotation * new Vector3 (Random.Range (-850,840), Random.Range (-542,546), 412);
			Instantiate (Enemy, transform.position + offset, Quaternion.Euler (new Vector3 (0, 0, Random.Range (0, 360))));
			cont++;
		}
	}
}
