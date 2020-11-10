using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusDetection : MonoBehaviour
{
    public EnemyController enemyController;
    public SphereCollider sphereCollider;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            enemyController.state = EnemyController.enemyState.Attacking;

        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sphereCollider.radius);
    }
}
