using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aileron : MonoBehaviour
{
    public float range = 5.0f;
    public float surfaceArea = 0.0f;
    Rigidbody physics;
    Air air;
    public Aerofoil aerofoil;

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
        float CL = aerofoil.lift.Evaluate(angleOfAttack);
        float CD = aerofoil.drag.Evaluate(angleOfAttack);
        float lift = 0.5f * air.density * relativeAir.sqrMagnitude * surfaceArea * CL;
        float drag = 0.5f * air.density * relativeAir.sqrMagnitude * surfaceArea * CD;
        physics.AddForceAtPosition(transform.forward * -drag, transform.position);
        physics.AddForceAtPosition(transform.up * lift, transform.position);
        Debug.DrawRay(transform.position, transform.up * lift, Color.yellow);
        Debug.DrawRay(transform.position, transform.forward * -drag, Color.green);
    }

	public void Adjust(float value)
	{
		transform.localRotation = Quaternion.Euler(value * range, 0.0f, 0.0f);
	}
}
