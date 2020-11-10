using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gliding : MonoBehaviour
{
    public float energy;
    public float fall;
    public float airspeed;
    public float liftRatio;
    public float minSpeed;
    public Rigidbody rb;
    public Text text;
    public GameManager gm;
    public GameObject keaFollower;
    public string birdFollower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Period))
            Time.timeScale *= 2;
        if (Input.GetKeyDown(KeyCode.Comma))
            Time.timeScale /= 2;
        energy = transform.position.y + rb.velocity.magnitude;

    }

    void FixedUpdate()
    {
        float roll = Input.GetAxis("Horizontal");
        float tilt = Input.GetAxis("Vertical");

        float yaw = 0; //Input.GetAxis("yaw") / 8;

        roll /= Time.timeScale;
        tilt /= Time.timeScale;
        yaw /= Time.timeScale;

        float tip = Vector3.Dot(transform.right, Vector3.up);
        yaw -= tip;

        /*if ((transform.forward + rb.velocity.normalized).magnitude < 1.4)
            tilt += 0.3f;
        if (tilt != 0)
            transform.Rotate(transform.right, tilt * Time.deltaTime * 10,Space.World);
        if (roll != 0)
            transform.Rotate(transform.forward, roll * Time.deltaTime * 10, Space.World);
        if (yaw != 0)
            transform.Rotate(Vector3.up, yaw * Time.deltaTime * 15, Space.World);
        */
        

        if (Input.GetButton("Jump"))
        {
            rb.AddForce(transform.forward * Time.deltaTime * 1000);
        }


        //Gravity
        rb.velocity -= Vector3.up * Time.deltaTime;

        //vertical
        Vector3 vertvel = rb.velocity - Vector3.Exclude(transform.up, rb.velocity);
        fall = vertvel.magnitude;
        rb.velocity -= vertvel * Time.deltaTime;
        rb.velocity += vertvel.magnitude * transform.forward * Time.deltaTime / 10;

        //drag
        Vector3 forwardDrag = rb.velocity - Vector3.Exclude(transform.forward, rb.velocity);
        rb.AddForce(-forwardDrag * forwardDrag.magnitude * Time.deltaTime / 1000);

        Vector3 sideDrag = rb.velocity - Vector3.Exclude(transform.right, rb.velocity);
        rb.AddForce(-sideDrag * sideDrag.magnitude * Time.deltaTime);
        

        airspeed = rb.velocity.magnitude;

        //tiltometer.rotation = Quaternion.LookRotation(Vector3.up);

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ring")
        {
            rb.AddForce(transform.forward * Time.deltaTime * 100000);
            gm.Spawnring();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            text.text = "Game Over";
        }
        if(collision.gameObject.tag == "Kea Flock")
        {
            Instantiate(keaFollower, transform.position, Quaternion.identity);
            birdFollower = "Kea";
            Destroy(collision.gameObject);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("speed");
    }
}
