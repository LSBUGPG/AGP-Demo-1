using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsGlider : MonoBehaviour
{
    public float start = 20.0f;
    public float centreOfMass = 0.0f;

    Rigidbody physics;

    public Aerofoil leftAileron;
    public Aerofoil rightAileron;
    public Aerofoil elevator;
    public Aerofoil rudder;

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
        if (Input.GetKeyDown(KeyCode.LeftBracket))
            transform.Rotate(Vector3.up * 5.0f);
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");
        leftAileron.SetAngle(-roll);
        rightAileron.SetAngle(roll);
        elevator.SetAngle(-pitch);
        rudder.SetAngle(-yaw);
    }
}
