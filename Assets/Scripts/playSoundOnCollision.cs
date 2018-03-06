using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundOnCollision : MonoBehaviour {

    public GameObject ball;
    public AudioSource audioSource;
    public AudioClip ballHitClip;
    public AudioClip goalClip;
    public AudioClip ringClip;
    public AudioClip bonusClip;
    public AudioClip capsuleClip;
	// Use this for initialization
	void Start () {
		audioSource = audioSource.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if ( col.gameObject.tag == "Player")
        {
            audioSource.clip = ballHitClip;
            audioSource.Play();
        }
        
        if (col.gameObject.name == "Capsule")
        {
            audioSource.clip = capsuleClip;
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "GoalTrigger")
        {
            audioSource.clip = goalClip;
            audioSource.Play();
        }

        if (col.gameObject.name == "RingTrigger")
        {
            audioSource.clip = ringClip;
            audioSource.Play();
        }

        if (col.gameObject.tag == "Bonus")
        {
            audioSource.clip = bonusClip;
            audioSource.Play();
        }
        
    }
}
