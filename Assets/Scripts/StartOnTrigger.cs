using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOnTrigger : MonoBehaviour {

    private GameObject[] balls;
    public GameObject startHoop;
    public GameTimer gameTimer;
    // Use this for initialization
    void Start ()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < balls.Length; ++i)
        {
            if (this.GetComponent<Renderer>().bounds.Intersects(balls[i].GetComponent<Renderer>().bounds))
            {
                gameTimer.StartTimer();
                startHoop.active = false;
            }
        }
    }
}
