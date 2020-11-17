using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerofoil : MonoBehaviour
{
    public float lift = 1.0f;
    public float drag = 0.0f;
    public float criticalAngle = 30.0f;
    public float surfaceArea = 0.0f;
    Rigidbody physics;
    Air air;
    public Transform graph;

    void Start()
    {
        air = FindObjectOfType<Air>();
        physics = GetComponentInParent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 relativeAir =
            transform.InverseTransformVector(air.GetWindVector() - 
                physics.GetPointVelocity(transform.position));

        float angleOfAttack = Vector3.SignedAngle(Vector3.back, relativeAir, Vector3.right);
        Vector3 liftVector = transform.up * relativeAir.y;
        Vector3 dragVector = (transform.right * relativeAir.x + transform.forward * relativeAir.z);
        float liftForce = 0.5f * dragVector.sqrMagnitude * surfaceArea * lift;
        float dragForce = 0.5f * liftVector.sqrMagnitude * surfaceArea * drag;
        physics.AddForceAtPosition(dragVector * dragForce, transform.position);
        physics.AddForceAtPosition(liftVector * liftForce, transform.position);
        // Debug.LogFormat(
        //     "{0} aoa {1} airspeed {2} lift {3}",
        //     name,
        //     angleOfAttack,
        //     relativeAir.magnitude,
        //     liftVector.magnitude * liftForce);
        Debug.DrawRay(transform.position, liftVector * liftForce, Color.yellow);
        Debug.DrawRay(transform.position, dragVector * dragForce, Color.green);
        if (graph != null)
        {
            graph.transform.position = new Vector3(0.0f, liftVector.magnitude * liftForce / 10.0f, angleOfAttack / 10.0f);
        }
    }

	public void SetAngle(float angle)
	{
		transform.localRotation = Quaternion.Euler(angle * criticalAngle, 0.0f, 0.0f);
	}
}
