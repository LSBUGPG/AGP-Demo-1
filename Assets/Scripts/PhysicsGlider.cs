using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsGlider : MonoBehaviour
{
    Rigidbody physics;

    void Start()
    {
        physics = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float velocity = physics.velocity.magnitude;
    }
}
