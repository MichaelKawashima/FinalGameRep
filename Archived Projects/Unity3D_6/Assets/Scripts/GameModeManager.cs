using UnityEngine;
using System.Collections;

public class GameModeManager : MonoBehaviour 
{
	public bool noReadyGUI;
	public bool isDamage;
	public bool isStun;
	
	public float player1Health;
	public float player2Health;

	public float player1Speed;
	public float player2Speed;

	public ParticleSystem isReady;

	public PlayerOneCharacterController PlayerOneCC;
	public PlayerTwoCharacterController PlayerTwoCC;
	public PlayerOneBulletWeapon PlayerOneBW;
	public PlayerTwoBulletWeapon PlayerTwoBW;
	public PlayerOneStats PlayerOneStats;
	public PlayerTwoStats PlayerTwoStats;
	// Use this for initialization
	void Start () 
	{
		PlayerOneCC = GameObject.Find("Player1").GetComponent<PlayerOneCharacterController>();
		PlayerTwoCC = GameObject.Find("Player2").GetComponent<PlayerTwoCharacterController>();
		PlayerOneBW = GameObject.Find("Player1BulletSpawner").GetComponent<PlayerOneBulletWeapon>();
		PlayerTwoBW = GameObject.Find("Player2BulletSpawner").GetComponent<PlayerTwoBulletWeapon>();
		PlayerOneStats = GameObject.Find("Player1").GetComponent<PlayerOneStats>();
		PlayerTwoStats = GameObject.Find("Player2").GetComponent<PlayerTwoStats>();

		if(noReadyGUI)
		{
			isReady.enableEmission = false;
			PlayerOneCC.isStart = true;
			PlayerTwoCC.isStart = true;
			PlayerOneBW.isStart = true;
			PlayerTwoBW.isStart = true;
		}
		else
		{
			StartCoroutine("Countdown");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isDamage){isStun = false;}
		if(isStun){isDamage = false;}

		if(PlayerOneStats.health == 0){StartCoroutine("Shake"); PlayerOneStats.health = -1;}
		if(PlayerTwoStats.health == 0){StartCoroutine("Shake"); PlayerTwoStats.health = -1;}

		player1Health = PlayerOneStats.health;
		player2Health = PlayerTwoStats.health;

		player1Speed = PlayerOneCC.playerSpeed;
		player2Speed = PlayerTwoCC.playerSpeed;
	}

	IEnumerator Countdown()
	{
		yield return new WaitForSeconds(isReady.duration);
		PlayerOneCC.isStart = true;
		PlayerTwoCC.isStart = true;
		PlayerOneBW.isStart = true;
		PlayerTwoBW.isStart = true;
	}

	//-----------CAMERA SHAKE-------------------------------------------------

	IEnumerator Shake() 
	{
		
		float elapsed = 0.0f;
		
		Vector3 originalCamPos = Camera.main.transform.position;
		
		while (elapsed < 1) 
		{
			elapsed += Time.deltaTime;          
			
			float percentComplete = elapsed / 1;         
			float damper = 1 - Mathf.Clamp(4.0f * percentComplete - 2.0f, 0.0f, 0.5f);

			float x = Random.value * 2.0f - 1.0f;
			float z = Random.value * 2.0f - 1.0f;
			x *= 0.6f * damper;
			z *= 0.6f * damper;
			
			Camera.main.transform.position = new Vector3(x, originalCamPos.y, z + 8);
			
			yield return null;
		}

		Camera.main.transform.position = originalCamPos;
	}
}
