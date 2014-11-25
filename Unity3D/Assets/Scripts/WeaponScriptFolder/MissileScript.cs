﻿using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour 
{
	void Update () 
	{
		{transform.Translate(Vector3.forward * Time.deltaTime * 10);}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Player2")
		{
			GameObject.Find("Player2").GetComponent<PlayerTwoStats>().health -= 
				GameObject.Find("Player2").GetComponent<PlayerTwoStats>().mineDamage;
			Destroy(gameObject);
		}

		if(other.name == "ObstacleRegular")
		{
			GameObject.Find ("Main Camera").GetComponent<GameGUIManager>().player1Score += 100;
			Destroy(other.gameObject);
		}
	}
}
