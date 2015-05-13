using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	protected float speed;

	[SerializeField]
	protected Camera camera;

	private float xMin;
	private float yMin;
	private float xMax;
	private float yMax;



	// Use this for initialization
	void Start () {
		Vector3 p = camera.ViewportToWorldPoint (new Vector3 (0,0,camera.nearClipPlane));
		xMin = p.x;
		yMin = p.y;

		p = camera.ViewportToWorldPoint (new Vector3 (1,1,camera.nearClipPlane));
		xMax = p.x;
		yMax = p.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.W)) {
			transform.Translate (speed * Vector2.up * Time.deltaTime);
		}

		if(Input.GetKey (KeyCode.A)) {
			transform.Translate (speed * -Vector2.right * Time.deltaTime);
		}

		if(Input.GetKey (KeyCode.S)) {
			transform.Translate (speed * -Vector2.up * Time.deltaTime);
		}

		if(Input.GetKey (KeyCode.D)) {
			transform.Translate (speed * Vector2.right * Time.deltaTime);
		}

		transform.position = new Vector2(
			Mathf.Clamp(transform.position.x, xMin, xMax),
			Mathf.Clamp(transform.position.y, yMin, yMax)
		);

		Debug.Log (transform.position.x);
	}
}
