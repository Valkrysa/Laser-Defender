﻿using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public AudioClip explosion;
	public float health = 150f;
	public GameObject projectile;
	public float projectileSpeed;
	public float shotsPerSecond = 0.5f;
	public ScoreKeeper scoreKeeper;
	public int scoreValue = 150;
	
	void Start(){
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper>();
	}
	
	void Update () {
		float probability = Time.deltaTime * shotsPerSecond;
		if(Random.value <  probability){
			Fire();
		}
	}
	
	void Fire(){
		Vector3 startPosition = transform.position + new Vector3(0f, -1f, 0f);
		GameObject beam = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector3(0, -projectileSpeed, 0);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0){
				Die();
			}
		}
	}
	
	void Die(){
		AudioSource.PlayClipAtPoint(explosion, transform.position, 10f);
		scoreKeeper.Score(scoreValue);
		Destroy(gameObject);
	}
	
}
