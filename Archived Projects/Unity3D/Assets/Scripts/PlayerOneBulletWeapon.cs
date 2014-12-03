using UnityEngine;
using System.Collections;

public class PlayerOneBulletWeapon : MonoBehaviour 
{
	public float attackSpeed;

	public int mineAmmo;
	public int missileAmmo;

	public GameObject bullet;
	public GameObject mine;
	public GameObject missile;

	bool canAttackBasic = true;
	bool canAttackMine = false;
	bool canAttackMissile = false;

	public bool basicWeapon = false;
	public bool mineWeapon = false;
	public bool missileWeapon = false;
	
	// Update is called once per frame
	void Update () 
	{
		if(basicWeapon == true){ShootBasic();}
		if(mineWeapon == true){ShootMine();}
		if(missileWeapon == true){ShootMissile();}

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{	
			basicWeapon = true; 
			mineWeapon = false; 
			missileWeapon = false;
			canAttackBasic = true;
			canAttackMine = false;
			canAttackMissile = false;
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			basicWeapon = false; 
			mineWeapon = true; 
			missileWeapon = false;
			canAttackBasic = false;
			canAttackMine = true;
			canAttackMissile = false;
		}
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			basicWeapon = false; 
			mineWeapon = false; 
			missileWeapon = true;
			canAttackBasic = false;
			canAttackMine = false;
			canAttackMissile = true;
		}
	}

	void ShootBasic()
	{
		if(Input.GetKeyDown(KeyCode.Space) && canAttackBasic)
		{
			StartCoroutine("BasicFireDelay");
		}
	}

	void ShootMine()
	{
		if(Input.GetKeyDown(KeyCode.Space) && canAttackMine && mineAmmo > 0)
		{
			StartCoroutine("MineFireDelay");
		}
	}

	void ShootMissile()
	{
		if(Input.GetKeyDown(KeyCode.Space) && canAttackMissile && missileAmmo > 0)
		{
			StartCoroutine("MissileFireDelay");
		}
	}
	
	IEnumerator BasicFireDelay()
	{
		if(canAttackBasic)
		{
			Instantiate(bullet, transform.position, Quaternion.identity);
			canAttackBasic = false;
			yield return new WaitForSeconds(attackSpeed);
			canAttackBasic = true;
			StopCoroutine("BasicFireDelay");
		}
	}

	IEnumerator MineFireDelay()
	{
		if(canAttackMine)
		{
			Instantiate(mine, transform.position, Quaternion.identity);
			mineAmmo -= 1;
			canAttackMine = false;
			yield return new WaitForSeconds(attackSpeed + 4);
			canAttackMine = true;
			StopCoroutine("MineFireDelay");
		}
	}

	IEnumerator MissileFireDelay()
	{
		if(canAttackMissile)
		{
			Instantiate(missile, transform.position, Quaternion.identity);
			missileAmmo -= 1;
			canAttackMissile = false;
			yield return new WaitForSeconds(attackSpeed + 6);
			canAttackMissile = true;
			StopCoroutine("MissileFireDelay");
		}
	}
}
