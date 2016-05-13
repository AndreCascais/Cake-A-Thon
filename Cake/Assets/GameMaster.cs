using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;

	public Transform spawnPoint;
	public Transform Try1;
	public float timeCounter=0f;
	public float spawnDelay=0f;
	public int score=0;

	void Start(){
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster>();
		}

	}


	public void Update(){
		timeCounter += Time.deltaTime;
		if (timeCounter >= spawnDelay) {
			gm.StartCoroutine (gm.SpawnPlatform ((int)(Random.value * 0)));
			timeCounter = 0f;
		}

	}

	public IEnumerator SpawnPlatform (int i){
		Debug.Log ("TODO:Add waiting for spawn sound");
		yield return new WaitForSeconds (spawnDelay);
		switch (i) {
		case 0:	
			{
				Instantiate (Try1, spawnPoint.position, spawnPoint.rotation);
				break;	
			}	

		default:
			{
				Debug.Log ("Ups");
				break;
			}
		}
		Debug.Log ("TODO:Add Spawn Particles");
	}
	//public static void KillArrow(Arrow arrow){
	//	Destroy (arrow.gameObject);
	//}

}
