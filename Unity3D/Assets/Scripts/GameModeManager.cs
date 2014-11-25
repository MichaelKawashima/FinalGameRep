using UnityEngine;
using System.Collections;

public class GameModeManager : MonoBehaviour 
{
	public bool isDamage;
	public bool isStun;
	
	public float player1Health;
	public float player2Health;

	public float player1Speed;
	public float player2Speed;

	public float player1BasicBallDamage;
	public float player2BasicBallDamage;

	public float player1BasicBallAttackSpeed;
	public float player2BasicBallAttackSpeed;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isDamage){isStun = false;}
		if(isStun){isDamage = false;}

		player1Health = GameObject.Find("Player1").GetComponent<PlayerOneStats>().health;
		player2Health = GameObject.Find("Player2").GetComponent<PlayerTwoStats>().health;

		player1Speed = GameObject.Find("Player1").GetComponent<PlayerOneCharacterController>().playerSpeed;
		player2Speed = GameObject.Find("Player2").GetComponent<PlayerTwoCharacterController>().playerSpeed;

		player1BasicBallDamage = GameObject.Find("Player1").GetComponent<PlayerOneStats>().basicBallDamage;
		player2BasicBallDamage = GameObject.Find("Player2").GetComponent<PlayerTwoStats>().basicBallDamage;

		player1BasicBallAttackSpeed = GameObject.Find("Player1BulletSpawner").GetComponent<PlayerOneBulletWeapon>().attackSpeed;
		player2BasicBallAttackSpeed = GameObject.Find("Player2BulletSpawner").GetComponent<PlayerTwoBulletWeapon>().attackSpeed;
	}
}
