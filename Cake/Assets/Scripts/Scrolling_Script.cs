using UnityEngine;
using System.Collections;

public class Scrolling_Script : MonoBehaviour {

	public float scrollSpeed = 50f;
	public Transform Platform;
	public float timeToDestroy = 2f;
	// Update is called once per frame
	void Update () {
		Platform.position = new Vector3 (Platform.position.x - scrollSpeed, Platform.position.y, Platform.position.z);
		Destroy (gameObject, timeToDestroy);
	}

}
