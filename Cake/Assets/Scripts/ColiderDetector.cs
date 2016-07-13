using UnityEngine;
using System.Collections;

public class ColiderDetector : MonoBehaviour {
	public Cake cake;
	public bool hit = false;
	void Start(){
		if (cake == null) {
			cake = GameObject.FindGameObjectWithTag ("Cake").GetComponent<Cake>();
		}

	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "Cake" && hit==false){
			hit = true;
			Debug.Log ("Hit");
			cake.TakeLive();		
		//Instantiate(explosionPrefab, pos, rot);
		//Destroy(gameObject);
		}
	}
}
