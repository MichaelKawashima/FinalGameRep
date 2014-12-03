using UnityEngine;
using System.Collections;

public class Bullet2Script : MonoBehaviour 
{
	public float ballSpeed;
	// Use this for initialization
	void Start () 
	{
		if(GameObject.Find("Player2").GetComponent<PlayerTwoCharacterController>().shootAngle == true)
			transform.localEulerAngles = new Vector3 (0, 210, 0);
		else
			transform.localEulerAngles = new Vector3 (0, -210, 0);
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
			transform.eulerAngles = new Vector3(0, 210, 0);
		}
		if(other.name == "RightMiddleWall")
		{
			transform.eulerAngles = new Vector3(0, 220, 0);
		}
		if(other.name == "RightOuterWall")
		{
			transform.eulerAngles = new Vector3(0, 230, 0);
		}
		
		if(other.name == "LeftInnerWall")
		{
			transform.eulerAngles = new Vector3(0, -210, 0);
		}
		if(other.name == "LeftMiddleWall")
		{
			transform.eulerAngles = new Vector3(0, -220, 0);
		}
		if(other.name == "LeftOuterWall")
		{
			transform.eulerAngles = new Vector3(0, -230, 0);
		}

		if(other.name == "Player1" && GameObject.Find("Main Camera").GetComponent<GameModeManager>().isDamage == true)
		{
			GameObject.Find("Player1").GetComponent<PlayerOneStats>().health -= GameObject.Find("Player1").GetComponent<PlayerOneStats>().basicBallDamage;
		}

		if(other.name == "Player1" && GameObject.Find("Main Camera").GetComponent<GameModeManager>().isStun == true)
		{
			GameObject.Find("Player1").GetComponent<PlayerOneCharacterController>().playerSpeed = 0;
		}

		if(other.name == "Player1"){Destroy(gameObject);}
	}
}
