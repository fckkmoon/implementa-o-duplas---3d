using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstaculos : MonoBehaviour {

    Player player;

	private void Start () {
        player = GameObject.FindObjectOfType<Player>();
	}

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.name == "Player") {
            // Kill the player
            player.Die();
        }
    }

    private void Update () {
	
	}
}