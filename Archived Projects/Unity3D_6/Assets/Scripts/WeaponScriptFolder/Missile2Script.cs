using UnityEngine;
using System.Collections;

public class Missile2Script : MonoBehaviour 
{
	void Update () 
	{
		{transform.Translate(Vector3.forward * Time.deltaTime * -10);}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Player1")
		{
			GameObject.Find("Player1").GetComponent<PlayerOneStats>().health -= 
				GameObject.Find("Player1").GetComponent<PlayerOneStats>().mineDamage;
			Destroy(gameObject);
		}
	}
}
