using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float speed = 5.0f;
	public float width = 10f;
	public float height = 5f;
	public float padding = 5f;
	
	private float xmin = -5f;
	private float xmax = 5f;
	private bool movingRight = true;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		
		xmin = leftMostPosition.x + padding;
		xmax = rightMostPosition.x - padding;
		
		
		foreach(Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		if(movingRight){
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if( transform.position.x >= xmax || transform.position.x <= xmin ){
			movingRight = !movingRight;
		}
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
