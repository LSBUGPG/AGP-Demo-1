using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsGlider : MonoBehaviour
{
    public float start = 20.0f;
    public float centreOfMass = 0.0f;

    Rigidbody physics;

    public Aileron leftAileron;
    public Aileron rightAileron;
    public Aileron elevator;
    public Aileron rudder;

    public Vector2 mouse;

    float roll = 0.0f;
    float pitch = 0.0f;
    float yaw = 0.0f;

    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.angularVelocity = Vector3.zero;
        physics.velocity = Vector3.zero;
        physics.AddForce(transform.forward * start, ForceMode.VelocityChange);
        physics.centerOfMass = Vector3.forward * centreOfMass;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = transform.localToWorldMatrix;
        Rigidbody physics = GetComponent<Rigidbody>();
        physics.centerOfMass = Vector3.forward * centreOfMass;
        Vector3 cog = physics.centerOfMass;
        Gizmos.DrawWireSphere(cog, 1.0f);
    }

    void Update()
    {
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");
        leftAileron.Adjust(-roll);
        rightAileron.Adjust(roll);
        elevator.Adjust(-pitch);
        rudder.Adjust(-yaw);
    }
}
