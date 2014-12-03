using UnityEngine;
using System.Collections;

public class GameGUIManager : MonoBehaviour 
{
	public GUIText player1ScoreGUI;
	public GUIText player2ScoreGUI;

	public int player1Score;
	public int player2Score;

	public GUIText player1BasicAmmoGUI;
	public GUIText player1MineAmmoGUI;
	public GUIText player1MissileAmmoGUI;
	public GUIText player2BasicAmmoGUI;
	public GUIText player2MineAmmoGUI;
	public GUIText player2MissileAmmoGUI;

	PlayerOneBulletWeapon weaponScript;
	PlayerTwoBulletWeapon weaponScript2;
	// Use this for initialization
	void Start () 
	{
		weaponScript = GameObject.Find("Player1BulletSpawner").GetComponent<PlayerOneBulletWeapon>();
		weaponScript2 = GameObject.Find("Player2BulletSpawner").GetComponent<PlayerTwoBulletWeapon>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		player1ScoreGUI.guiText.text = "Player 1 Score = " + player1Score.ToString("0");
		player2ScoreGUI.guiText.text = "Player 2 Score = " + player2Score.ToString("0");

		player1BasicAmmoGUI.guiText.text   = "Bullet = Infinite";
		player1MineAmmoGUI.guiText.text    = "Mine = " + weaponScript.mineAmmo;
		player1MissileAmmoGUI.guiText.text = "Missile = " + weaponScript.missileAmmo;
		player2BasicAmmoGUI.guiText.text   = "Bullet = Infinite";
		player2MineAmmoGUI.guiText.text    = "Mine = " + weaponScript2.mineAmmo;
		player2MissileAmmoGUI.guiText.text = "Missile = " + weaponScript2.missileAmmo;
	}
}
