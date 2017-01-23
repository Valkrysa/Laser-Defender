using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public float padding = 0.01f;
	
	private float xmin = -5;
	private float xmax = 5;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		
		xmin = leftMostPosition.x + padding;
		xmax = rightMostPosition.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if(Input.GetKey(KeyCode.D)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
