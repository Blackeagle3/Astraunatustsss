using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {
    public Transform playerPos;
    public float smoothDamp = 0.2f;
    Vector3 zv2 = Vector3.zero;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 v2 = new Vector3(playerPos.position.x, playerPos.position.y, 0);
        transform.position = Vector3.SmoothDamp(transform.position, v2, ref zv2, smoothDamp);
	}
}
