using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

    public GameObject hammer;
    public GameObject baseballBat;
    public GameObject pillar;
	// Use this for initialization
	void Start () {
        Physics.IgnoreCollision(pillar.GetComponent<Collider>(), hammer.GetComponent<Collider>());
        Physics.IgnoreCollision(pillar.GetComponent<Collider>(), baseballBat.GetComponent<Collider>());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
