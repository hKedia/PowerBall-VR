using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	public int points;
	private GameObject[] balls;
	private SumScoreExample sumScore;
	private bool[] ballInTrigger;

	// Use this for initialization
	void Start () {
		balls = GameObject.FindGameObjectsWithTag("Ball");
		sumScore = Object.FindObjectOfType<SumScoreExample>();

		ballInTrigger = new bool[balls.Length];
		for (int i = 0; i < balls.Length; ++i) {
			ballInTrigger[i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < balls.Length; ++i) {
		    if (this.GetComponent<Renderer>().bounds.Intersects(balls[i].GetComponent<Renderer>().bounds)) {
		    	if (!ballInTrigger[i]) {
		    		sumScore.AddPoints(points);
		    		ballInTrigger[i] = true;
		    	}

		    } else if (ballInTrigger[i]) {
		    	ballInTrigger[i] = false;
		    }
		}
	}
}
