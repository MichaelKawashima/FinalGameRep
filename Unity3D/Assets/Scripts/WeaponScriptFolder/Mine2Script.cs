using UnityEngine;
using System.Collections;

public class Mine2Script : MonoBehaviour 
{
	public float maxZ;
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.z > maxZ){transform.Translate(Vector3.forward * Time.deltaTime * -5);}
		if(transform.position.z <= maxZ) 
		{StartCoroutine("Countdown"); transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);}
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
	
	IEnumerator Countdown()
	{
		yield return new WaitForSeconds(7);
		Destroy(gameObject);
	}
}
