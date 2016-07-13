using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Tiling : MonoBehaviour {

	public int offsetX = 2;
	public bool hasARightBuddy=false;
	public bool hasALeftBuddy=false;
	public bool reverseScale = false;	
	private float spriteWidth = 0f;
	private Camera cam;
	private Transform myTransform;



	// Use this for initialization
	void Awake(){
		cam = Camera.main;
		myTransform = transform;
	}
	void Start () {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer> ();
		spriteWidth = sRenderer.sprite.bounds.size.x;

	}
	
	// Update is called once per frame
	void Update () {
		if (IsOutOfScreen (this.gameObject))
			Destroy (this.gameObject);
		float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
		float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
		float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;
		if (hasALeftBuddy == false || hasARightBuddy == false) {
			if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightBuddy == false) {
				MakeNewBuddy (1);
				hasARightBuddy = true;
			}
			else if(cam.transform.position.x<=edgeVisiblePositionLeft+offsetX && hasALeftBuddy==false){
				MakeNewBuddy (-1);
				hasALeftBuddy = true;
			}
		}
	}

void MakeNewBuddy(int rightOrLeft){
		Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);	
		Transform newBuddy = Instantiate (myTransform,newPosition,myTransform.rotation) as Transform;
		if (reverseScale == true) {
			newBuddy.localScale = new Vector3 (newBuddy.localScale.x * -1,newBuddy.localScale.y,newBuddy.localScale.z);

		}
		newBuddy.parent = myTransform.parent;
		if (rightOrLeft > 0) {
			newBuddy.GetComponent<Tiling> ().hasALeftBuddy = true;
		}
		else {
			newBuddy.GetComponent<Tiling> ().hasARightBuddy = true;
		}
}
public bool IsOutOfScreen(GameObject o, Camera cam = null)
{
	bool result = false;
	Renderer ren = o.GetComponent<Renderer>();
	if(ren){
		if (cam == null) cam = Camera.main;
		Vector2 sdim = SpriteScreenSize(o,cam);
		Vector2 pos = cam.WorldToScreenPoint(o.transform.position);
		Vector2 min = pos - sdim;
		Vector2 max = pos + sdim;
		if( min.x > Screen.width || max.x < 0f || 
			min.y > Screen.height || max.y < 0f) {
			result = true;
		}
	}
	else{
		//TODO: throw exception or something
	}
	return result;
}

public Vector2 SpriteScreenSize(GameObject o, Camera cam = null)
{
	if (cam == null) cam = Camera.main;
	Vector2 sdim = new Vector2();
	Renderer ren = o.GetComponent<Renderer>() as Renderer;
	if (ren)
	{            
		sdim = cam.WorldToScreenPoint(ren.bounds.max) -
			cam.WorldToScreenPoint(ren.bounds.min);
	}
	return sdim;
}
}