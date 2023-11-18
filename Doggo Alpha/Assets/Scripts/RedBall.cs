using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : MonoBehaviour
{
    public float Speed = 1.0f;
    private Rigidbody objectRb;
    private float ZDestroy = -5.0f;

    // Start will be called before frame
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward * -Speed);

        if (transform.position.z < ZDestroy)
        {
            Destroy(gameObject);
        }
    }
}


