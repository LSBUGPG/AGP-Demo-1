using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    
    public float enemySpeed;
    public GameObject player;
    public float MaxChaseDistance;
    public float idleRange;
    Vector3 newPosition;
    public GameObject huntedUI;

    public enum enemyState
    {
        Idle,
        Attacking,
        Retreating
    }

    public enemyState state;
    
    void Start()
    {
        state = enemyState.Idle;
        newPosition = transform.parent.position;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        switch (state)
        {
            case enemyState.Idle:
                Idle();
                break;
            case enemyState.Attacking:
                Attack();
                break;
            case enemyState.Retreating:
                Retreating();
                break;
            default:
                break;
        }
    }

    public void Idle()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition, enemySpeed * Time.deltaTime);

        if (transform.position == newPosition)
        {
            newPosition = new Vector3(Random.Range(transform.parent.position.x - idleRange,transform.parent.position.x + idleRange),
                Random.Range(transform.parent.position.y, transform.parent.position.y + idleRange),
                Random.Range(transform.parent.position.z - idleRange, transform.parent.position.z + idleRange));
        }
    }

    public void Attack()
    {
        if (Vector3.Distance(transform.parent.position, transform.position) < MaxChaseDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        } else
        {
            state = enemyState.Retreating;
        }
    }

    public void Retreating()
    {
        if (transform.position != transform.parent.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.position, enemySpeed * Time.deltaTime);
        } else
        {
            state = enemyState.Idle;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            state = enemyState.Retreating;
        }
    }

}
