using UnityEngine;
using System.Collections;

public class BGMove : MonoBehaviour {

	private float spriteWidth;
	public SpriteRenderer spriteRenderer;
	public Transform cameraTransform;


	// Use this for initialization
	void Start () {
		spriteWidth = 2.5f * spriteRenderer.sprite.bounds.size.x;
		Debug.Log (spriteWidth);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (5.0f * Vector3.left * Time.deltaTime);

		if (transform.position.x + spriteWidth < cameraTransform.position.x) {

			Vector3 newPos = transform.position;
			newPos.x += 2.0f * spriteWidth;
			transform.position = newPos;
		}
	}
}
