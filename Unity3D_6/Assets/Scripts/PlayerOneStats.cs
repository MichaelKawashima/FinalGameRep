﻿using UnityEngine;
using System.Collections;

public class PlayerOneStats : MonoBehaviour 
{
	public float health;
	public float basicBallDamage;
	public float mineDamage;
	public float missileDamage;	
	// Update is called once per frame
	void Update () 
	{
		if(health <= 0){Destroy(gameObject); GameObject.Find ("Main Camera").GetComponent<GameGUIManager>().player2Score += 200;}
	}
}
