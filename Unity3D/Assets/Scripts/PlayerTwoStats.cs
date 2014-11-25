using UnityEngine;
using System.Collections;

public class PlayerTwoStats : MonoBehaviour 
{
	public float health;
	public float basicBallDamage;
	public float mineDamage;
	public float missileDamage;	
	// Update is called once per frame
	void Update () 
	{
		if(health <= 0){Destroy(gameObject);}
	}
}
