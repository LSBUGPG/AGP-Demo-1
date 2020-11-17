using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    public float velocity = 25.0f;

	internal Vector3 GetWindVector()
	{
		return transform.forward * velocity;
	}
}
