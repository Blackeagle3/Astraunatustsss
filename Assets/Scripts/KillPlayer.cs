using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public GameObject Player;
    public Transform spawnPoint;

	// Use this for initialization
	void Start () {
        spawnPoint.position = GameObject.FindWithTag("Respawn").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered deathzone");

        if (other.tag == "Player")
        {
            Player.transform.position = spawnPoint.position;
        }
    }
}
