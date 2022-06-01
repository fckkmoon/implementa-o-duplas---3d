using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstaculos : MonoBehaviour {

    Player player;

	private void Start () {
        player = GameObject.FindObjectOfType<Player>();
        Debug.Log("Start");
	}

    private void OnCollisionEnter (Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.name == "Cabeça") {
            // Kill the player
            player.Die();
        }
    }

    private void Update () {
	
	}
}