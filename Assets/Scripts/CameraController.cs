using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject Player;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = this.gameObject.transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position = Player.transform.position + offset;
	}
}
