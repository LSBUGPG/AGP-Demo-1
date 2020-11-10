using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject player;
    public Transform playerT;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerT = gameObject.transform.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.LookAt(playerT);
        }
    }
}
