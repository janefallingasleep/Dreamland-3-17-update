using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowman_static_attack : MonoBehaviour {
	
	public GameObject projectile;
	private float timeBtwShots;
	public float startTimeBtwShot;
	public float lookingDistance;
	public float rotaiondamping;
	public Transform player;
	bool start_leepy_attack;

	public void startLeepyAttack(){
		start_leepy_attack = true;
	}

	public void finishLeepyAttack(){
		start_leepy_attack = false;
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("leepy_head").transform;
		timeBtwShots = startTimeBtwShot;
		start_leepy_attack = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(transform.position, player.position) < lookingDistance){
			lookAtPlayer();
		}
		if (start_leepy_attack) {
			if (timeBtwShots <= 0) {
				Instantiate (projectile, transform.position, transform.rotation);
				timeBtwShots = startTimeBtwShot;
			} else {
				timeBtwShots -= Time.deltaTime;
			}
		}
		
	}
		
	void lookAtPlayer(){
		
		Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotaiondamping);
	}
}
