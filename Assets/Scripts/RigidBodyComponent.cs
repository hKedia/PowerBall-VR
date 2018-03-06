using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyComponent : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(0, 0.5f, 0);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bonus"))
        {

            other.gameObject.SetActive(false);
        }

    }
}
