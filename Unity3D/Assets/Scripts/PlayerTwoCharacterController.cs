using UnityEngine;
using System.Collections;

public class PlayerTwoCharacterController : MonoBehaviour 
{
	public float maxX;
	public float minX;

	public bool shootAngle;

	[HideInInspector]
	public float playerSpeed;
	
	private float tempSpeed;
	// Use this for initialization
	void Start ()
	{
		tempSpeed = playerSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 moveDir = Vector3.zero;
		moveDir.x = Input.GetAxis("Horizontal2");
		transform.position += moveDir * playerSpeed * Time.deltaTime;

		if(playerSpeed == 0)
		{
			StartCoroutine("Stun");
		}

		//-----------------------PLAYER MOVEMENT RESTRICTION-------------
		
		if(transform.position.x >= maxX || transform.position.x <= minX)
		{
			transform.position -= moveDir * playerSpeed * Time.deltaTime;
		}

		//-----------------------SHOOT ANGLE-----------------------------
		
		if(Input.GetKeyDown(KeyCode.UpArrow)){shootAngle = true;}
		if(Input.GetKeyDown(KeyCode.DownArrow)){shootAngle = false;}
	}
	
	IEnumerator Stun()
	{
		yield return new WaitForSeconds(3);
		playerSpeed = tempSpeed;
		StopCoroutine("Stun");
	}
}
