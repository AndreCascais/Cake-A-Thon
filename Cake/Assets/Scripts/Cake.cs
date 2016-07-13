using UnityEngine;
using System.Collections;

public class Cake : MonoBehaviour {

	// Use this for initialization

	[System.Serializable]
	public class PlayerStats{
		public int lives=2;
	}
	public PlayerStats playerStats = new PlayerStats();
	public void TakeLive(){
		playerStats.lives--;
		Debug.Log (playerStats.lives);
		if(playerStats.lives==0){
			Debug.Log ("Era suposto rip");
			GameMaster.KillCake(this);
		}
	}
}