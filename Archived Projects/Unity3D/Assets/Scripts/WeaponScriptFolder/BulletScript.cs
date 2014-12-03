using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour 
{
	public float ballSpeed;
	// Use this for initialization
	void Start () 
	{
		if(GameObject.Find("Player1").GetComponent<PlayerOneCharacterController>().shootAngle == false)
			transform.localEulerAngles = new Vector3 (0, 30, 0);
		else
			transform.localEulerAngles = new Vector3 (0, -30, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.forward * Time.deltaTime * ballSpeed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "RightInnerWall")
		{
			transform.eulerAngles = new Vector3(0, -30, 0);
		}
		if(other.name == "RightMiddleWall")
		{
			transform.eulerAngles = new Vector3(0, -40, 0);
		}
		if(other.name == "RightOuterWall")
		{
			transform.eulerAngles = new Vector3(0, -50, 0);
		}

		if(other.name == "LeftInnerWall")
		{
			transform.eulerAngles = new Vector3(0, 30, 0);
		}
		if(other.name == "LeftMiddleWall")
		{
			transform.eulerAngles = new Vector3(0, 40, 0);
		}
		if(other.name == "LeftOuterWall")
		{
			transform.eulerAngles = new Vector3(0, 50, 0);
		}

		if(other.name == "Player2" && GameObject.Find("Main Camera").GetComponent<GameModeManager>().isDamage == true)
		{
			GameObject.Find("Player2").GetComponent<PlayerTwoStats>().health -= GameObject.Find("Player2").GetComponent<PlayerTwoStats>().basicBallDamage;
		}

		if(other.name == "Player2" && GameObject.Find("Main Camera").GetComponent<GameModeManager>().isStun == true)
		{
			GameObject.Find("Player2").GetComponent<PlayerTwoCharacterController>().playerSpeed = 0;
		}

		if(other.name == "Player2"){Destroy(gameObject);}

		// OBSTACLE REGULAR

		if(other.name == "ObstacleRegular")
		{
			GameObject.Find ("Main Camera").GetComponent<GameGUIManager>().player1Score += 100;
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
