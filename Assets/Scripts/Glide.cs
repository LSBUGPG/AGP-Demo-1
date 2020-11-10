using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glide : MonoBehaviour
{
    public int glideTime;
    public int damageTaken;

    public double posX;
    public double posY;
    public double posZ;

    public double velX;
    public double velY;
    public double velZ;

    public GameObject player;

    private Vector3 rot;
    public float percentage;

    public GameObject cam;

    private void Update()
    {
        //Rotate X
        float xInput = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        xInput = rot.x += 50 * xInput;

        //Rotate Y
        float yInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        yInput = rot.y += 50 * yInput;

        transform.rotation = Quaternion.Euler(rot);

        percentage = rot.x / 65;
        Quaternion look = cam.transform.rotation;
        tick(false , look.y * -1 ,look.x * -1);
    }
    /**
	* Simulates a Minecraft tick (20 per second).
	* The pitch and yaw are the look direction of the player.
	*/
    public void tick(bool isCreative, double yaw, double pitch)
    {
        Debug.Log(yaw + " " + pitch);
        if (!isCreative && (this.glideTime + 1) % 20 == 0)
        {
            this.damageTaken++;
        }

        //I did some simplifing of the folowing to reduce the number of negatives and trig functions
        double yawcos = Mathf.Cos((float)-yaw - Mathf.PI);
        double yawsin = Mathf.Sin((float)-yaw - Mathf.PI);
        double pitchcos = Mathf.Cos((float)pitch);
        double pitchsin = Mathf.Sin((float)pitch);

        double lookX = yawsin * -pitchcos;
        double lookY = -pitchsin;
        double lookZ = yawcos * -pitchcos;

        double hvel = Mathf.Sqrt((float)(velX * velX + velZ * velZ));
        double hlook = pitchcos; //Math.sqrt(lookX * lookX + lookZ * lookZ)
        double sqrpitchcos = pitchcos * pitchcos; //In MC this is multiplied by Math.min(1.0, Math.sqrt(lookX * lookX + lookY * lookY + lookZ * lookZ) / 0.4), don't ask me why, it should always =1

        //From here on, the code is identical to the code found in net.minecraft.entity.EntityLivingBase.moveEntityWithHeading(float, float) or rq.g(float, float) in obfuscated 15w41b
        this.velY += -0.08 + sqrpitchcos * 0.06;

        if (this.velY < 0 && hlook > 0)
        {
            double yacc = this.velY * -0.1 * sqrpitchcos;
            this.velY += yacc;
            this.velX += lookX * yacc / hlook;
            this.velZ += lookZ * yacc / hlook;
        }
        if (pitch < 0)
        {
            double yacc = hvel * -pitchsin * 0.04;
            this.velY += yacc * 3.5;
            this.velX -= lookX * yacc / hlook;
            this.velZ -= lookZ * yacc / hlook;
        }
        if (hlook > 0)
        {
            this.velX += (lookX / hlook * hvel - this.velX) * 0.1;
            this.velZ += (lookZ / hlook * hvel - this.velZ) * 0.1;
        }

        this.velX *= 0.99;
        this.velY *= 0.98;
        this.velZ *= 0.99;

        this.posX += this.velX;
        this.posY += this.velY;
        this.posZ += this.velZ;

        this.glideTime++;
        //player.GetComponent<Rigidbody>().velocity = new Vector3 ((float)this.velX, (float)this.velY, (float)this.velZ);
        player.transform.position = new Vector3((float)this.posX, (float)this.posY, (float)this.posZ);
        player.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
    }

    /** 
	* Checks if the player is currently in a gliding state.
	* As you can see, if the player is in creative, they will remain gliding even if on the ground. They will stop gliding once they move (but that functionality is not shown here).
	*/
    public bool isGliding(bool isCreative, bool isOnGround, float fallDistance)
    {
        if (isCreative)
        {
            return glideTime > 0;
        }
        else
        {
            return !isOnGround && fallDistance >= 1.0f;
        }
    }
}
