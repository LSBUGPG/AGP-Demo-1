using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity;

public class GlidingControl : MonoBehaviour
{

    public float speed;
    public float boost = 200;
    public float normal = 80;
    public float drag = 6;
    public int weight;
    public int wetWeight;
    public int startWeight;
    public float beforeIncSpeed;

    public Rigidbody rb;

    private Vector3 rot;

    //public Vector3 m_NewForce;
    public float percentage;

    public GameManager gm;

    public GameObject manager;
    public GameObject keaFollower;

    public GameObject currentFollower;
    public string birdFollower;

    void Start()
    {
        weight = startWeight;

        rb = GetComponent<Rigidbody>();
        rot = transform.eulerAngles;
        //m_NewForce = new Vector3(-5.0f, 1.0f, 0.0f);

    }
    // Update is called once per frame
    void Update()
    {
        //Rotate X
        rot.x += 50 * Input.GetAxis("Vertical") * Time.deltaTime;

        //Rotate Y
        rot.y += 50 * Input.GetAxis("Horizontal") * Time.deltaTime;

        //Rotate Z
        rot.z += -5 * Input.GetAxis("Horizontal");
        rot.z = Mathf.Clamp(rot.z, -5, 5);

        transform.rotation = Quaternion.Euler(rot);

        percentage = rot.x / 65;

        float mod_drag = (percentage * -2) + drag;
        float mod_speed = percentage * (13.8f - 12.5f) + speed;

        rb.drag = mod_drag;
        Vector3 downForce = manager.transform.up * weight;

        Vector3 localV = transform.InverseTransformDirection(rb.velocity);
        localV.z = mod_speed;

        downForce += localV;
        rb.velocity = transform.TransformDirection(localV);


        if (Input.GetKeyDown("space"))
        {
            if(birdFollower == "Kea")
            {
                StartCoroutine(SpeedInc());
                Destroy(currentFollower);
                birdFollower = " ";
            }
        }
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ring")
        {
            rb.AddForce(transform.forward * Time.deltaTime * 100000);
            gm.Spawnring();
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Wall")
        {
            gm.endGame();
        }

        if (collision.gameObject.tag == "Kea Flock")
        {
            
            currentFollower = Instantiate(keaFollower, transform.position, Quaternion.identity);
            birdFollower = "Kea";
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Rain Cloud")
        {

        }
    }
    public IEnumerator ApplyWet()
    {
        weight = wetWeight;
        yield return new WaitForSeconds(5);
        weight = startWeight;
    }


    public IEnumerator SpeedInc()
    {
        beforeIncSpeed = speed;
        speed += 50;
        yield return new WaitForSeconds(5);
        speed = beforeIncSpeed;
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("speed");
    }

}
