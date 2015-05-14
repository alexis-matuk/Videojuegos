using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//script que maneja los disparos de Aphelion
public class BulletFireScript : MonoBehaviour {
/*Declaración de variables*/
	public float time;
	public List<GameObject> bullets;
	public int currentBullet = 0;
	bool allowFire = true;
	bool laserSpawned = false;
	bool changedBullet = false;
	
	//función principal para disparar
	void Fire () {
		Vector3 dir = new Vector3(Input.GetAxis("HorizontalRotate"), Input.GetAxis("VerticalRotate"), 0);//vector direccion
		if(!(Mathf.Abs(dir.x)<0.01 && Mathf.Abs(dir.y)<0.01))//si se está rotando
		{
			//disparar con diferente fireRate dependiendo de la bala
			if(bullets[currentBullet].gameObject.tag=="X-Wing"){
				if(!changedBullet){
					time = 0.2f;
					changedBullet = true;
				}
			}
			else if(bullets[currentBullet].gameObject.tag == "Wave"){
				if(!changedBullet){
					time = 0.70f;
					changedBullet = true;	
				}
			}
			else if(bullets[currentBullet].gameObject.tag == "FireBurning"){
				if(!changedBullet){
					time = 0.035f;
					changedBullet = true;
				}
			}
			else if(bullets[currentBullet].gameObject.tag == "NastyHarry"){
				if(!changedBullet){
					time = .15f;
					changedBullet = true;
				}
			}
			else if (bullets[currentBullet].gameObject.tag == "normalBullet"){
				if(!changedBullet){
					time = 0.07f;
					changedBullet = true;
				}
			}
			
			//instanciar bala
			Instantiate (bullets[currentBullet], transform.Find("tip").position, transform.Find("tip").rotation);
		}
		
	}
	
	void Update(){
		fireLaser();//función específica para disparar láser
		if(laserSpawned && currentBullet!=3)
		{
			//manejo de instanciar y destruir el láser, ya que es diferente a una bala
			Destroy(GameObject.FindGameObjectWithTag("Laser"));
			laserSpawned = false;
		}
	 	if(bullets[currentBullet].gameObject.tag != "Laser")
		{
			//llamar a corrutina de disparo
			if(allowFire)
				StartCoroutine(faya ());
		}
	}
	
	//función para disparar láser
	void fireLaser()
	{
		Vector3 dir = new Vector3(Input.GetAxis("HorizontalRotate"), Input.GetAxis("VerticalRotate"), 0);//vector dirección
		if(bullets[currentBullet].gameObject.tag == "Laser" && !laserSpawned)//si disparas láser y no se ha instanciado
		{
			if(!(Mathf.Abs(dir.x)<0.01 && Mathf.Abs(dir.y)<0.01)){//si se está rotando
				Instantiate(bullets[currentBullet], transform.FindChild("tip").position, transform.FindChild("tip").rotation);//instanciar láser
				laserSpawned = true;
			}
		}
		if((Mathf.Abs(dir.x)<0.01 && Mathf.Abs(dir.y)<0.01)&&laserSpawned)//si ya se instanció el láser
		{
			Destroy(GameObject.FindGameObjectWithTag("Laser"));//destruir el láser previamente instanciado
			laserSpawned=false;
		}
	}
	
	//corrutina principal para disparar
	IEnumerator faya()
	{
		allowFire = false;
		Fire ();//llamar a función de disparo
		yield return new WaitForSeconds(time);//esperar un tiempo para disparar otra vez (fireRate)
		allowFire = true;
	}
	
	//regresar la bala a 0. se llama cuando golpean a Aphelion
	public void resetBullet()
	{
		currentBullet = 0;
		changedBullet = false;
		GameObject.Find("currentPowerUp").GetComponent<Image>().enabled = false;
	}
	
	//cambiar bala a disparar
	public void setCurrentBullet(int curr)
	{
		currentBullet = curr;
		changedBullet = false;
		GameObject.Find("currentPowerUp").GetComponent<Image>().enabled = true;
		GameObject.Find("currentPowerUp").GetComponent<RectTransform>().sizeDelta = new Vector2(80,80);
	}
	
}
