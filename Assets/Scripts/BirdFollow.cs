using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFollow : MonoBehaviour
{
    public GameObject playerFollow;
    public bool fPlayer;
    // Start is called before the first frame update
    void Start()
    {
        playerFollow = GameObject.FindWithTag("FollowSpot"); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = Vector3.MoveTowards(transform.position, playerFollow.transform.position,10000);
    }
}
