using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMove : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
            transform.Rotate(new Vector3(0, 100, 0));
    }
}
