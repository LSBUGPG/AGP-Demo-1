using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerofoil : MonoBehaviour
{
    public AnimationCurve lift;
    public AnimationCurve drag;
    public bool debug = false;
    Air air;

    void Start()
    {
        air = FindObjectOfType<Air>();
    }

    void FixedUpdate()
    {
        if (debug)
        {
            float angleOfAttack = Vector3.SignedAngle(-transform.forward, air.GetWindVector(), transform.right);
            float CL = lift.Evaluate(angleOfAttack);
            Debug.LogFormat("{0} aoa {1} lift {2}", name, angleOfAttack, CL);
        }
    }
}
