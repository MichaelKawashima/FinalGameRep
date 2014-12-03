using UnityEngine;
using System.Collections;

public class PigScript : MonoBehaviour 
{
	public int health = 2;

	private GameGUIManager guiManager;
	// Use this for initialization
	void Start () 
	{
		guiManager = GameObject.Find ("Main Camera").GetComponent<GameGUIManager>();
	}

	void Update ()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * 1);
		transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Bullet(Clone)")
		{
			health -= 1;
			Destroy(other.gameObject);
			if(health <= 0){Destroy(gameObject); guiManager.player1Score += 30;}
		}
		
		if(other.name == "Bullet 2(Clone)")
		{
			health -= 1;
			Destroy(other.gameObject);
			if(health <= 0){Destroy(gameObject); guiManager.player2Score += 30;}
		}

		if(other.name == "Missile(Clone)")
		{
			health -= 2;
			Destroy(other.gameObject);
			if(health <= 0){Destroy(gameObject); guiManager.player1Score += 30;}
		}
		
		if(other.name == "Missile 2(Clone)")
		{
			health -= 2;
			Destroy(other.gameObject);
			if(health <= 0){Destroy(gameObject); guiManager.player2Score += 30;}
		}
	}
}
