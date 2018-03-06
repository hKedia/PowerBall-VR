using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour {
	private float startTime = 0f;
	public UnityEngine.UI.Text textTime;
	public SumScoreExample sumScore;
	public int gameTimeSeconds = 60;
	private bool started = false;
    public AudioSource audioSource;
    public AudioClip newGame;
    public AudioClip gameOver;

    public GameObject startHoop;

	public void StartTimer() {
		started = true;
        sumScore.ResetPoints();
        sumScore.SetStarted(true);
		startTime = Time.time;
        audioSource = audioSource.GetComponent<AudioSource>();
        audioSource.clip = newGame;
        audioSource.loop = true;
        audioSource.Play();
	}
	// Update is called once per frame
	void Update () {
		if (started) {
			float curTime = Time.time - startTime;

			if (curTime > gameTimeSeconds) {
				sumScore.SetStarted(false);
				sumScore.CheckHighScore();
                startHoop.active = true;
                audioSource.clip = gameOver;
                audioSource.loop = false;
                audioSource.Play();
				started = false;
			}

			int countdownMinutes = (int) (gameTimeSeconds - curTime) / 60;
			int countdownSeconds = (int) (gameTimeSeconds - curTime) % 60;

			textTime.text = string.Format ("{0:00}:{1:00}", countdownMinutes, countdownSeconds); 
		}
	}
}
