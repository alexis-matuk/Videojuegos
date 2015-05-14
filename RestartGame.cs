using UnityEngine;
using System.Collections;

//script para reiniciar el juego
public class RestartGame : MonoBehaviour {
	bool gameEnded = false;//boolean para determinar si se acabó el juego
	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	void Start()
	{
		//quitar el mesh renderer de las paredes para un mejor efecto
		GameObject[] paredes = GameObject.FindGameObjectsWithTag("Wall");
		for(int i=0; i<paredes.Length; i++)
		{
			paredes[i].GetComponent<MeshRenderer>().enabled = false;
		}
	}
	
	void Update () {
		if(Input.GetButton("Select") && gameEnded)//si se acabó el juego y se aprieta select
		{
			Time.timeScale = 1;//regresar el tiempo a 1 (tiempo normal)
			Destroy(GameObject.Find("GeneralScriptHandler"));
			Application.LoadLevel(Application.loadedLevel);//recargar el nivel actual
		}
	}
	
	//cambiar gameEnded a verdadero
	public void endGame()
	{
		gameEnded = true;
	}
}