using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Joystick joystick;
    protected Joybutton joybutton;
    protected float x;
    protected float y;
    protected float z;
    public AudioSource playerSounds;
    public AudioClip yum;
    public AudioClip death;

    public GameObject butterBones;

    public ProgressBar Pb;

    public bool alive = true;
    public bool invisible = false;

    protected float powerTimer = 3f;
    protected float cooldown = 0f;

    Rigidbody rigidbody;

    public SkinnedMeshRenderer mesh;
    public SkinnedMeshRenderer outline;

    //protected bool something;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        rigidbody = GetComponent<Rigidbody>();
        outline.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (alive) {
            rigidbody.velocity = new Vector3(joystick.Horizontal * 25f + Input.GetAxis("Horizontal") * 25f, 0, joystick.Vertical * 25f + Input.GetAxis("Vertical") * 25f);

            if (joystick.Vertical > 0f)
            {
                z = (joystick.Horizontal * 90f);
            }
            else if (joystick.Vertical == 0f)
            {
                z = 0;
            }
            else
            {
                if (joystick.Horizontal > 0f)
                {
                    z = (90f) + (joystick.Vertical * -90f);
                }
                else
                {
                    z = (-90f) + (joystick.Vertical * 90f);
                }
            }

            this.transform.eulerAngles = new Vector3(0, z, 0);

            if (cooldown >= 0f)
            {
                cooldown -= Time.deltaTime;
            }

            if (!invisible && (joybutton.Pressed) && cooldown <= 0f)
            {
                invisible = true;
                Debug.Log("It has been done my lord.");
                mesh.enabled = false;
                outline.enabled = true;
            }

            if (invisible == true)
            {
                powerTimer -= Time.deltaTime;

                if (powerTimer <= 0f)
                {
                    powerTimer = 3f;
                    invisible = false;
                    Debug.Log("It is over my lord...");
                    outline.enabled = false;
                    mesh.enabled = true;
                    cooldown = 2f;
                }
            }
        }
        else
        {
            rigidbody.constraints = RigidbodyConstraints.None;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Nectar")
        {
            Destroy(other.gameObject);
            Debug.Log("Destroyed");

            Pb.BarValue += 25;

            playerSounds.clip = yum;
            playerSounds.Play();
        }

        if (other.gameObject.tag == "Bird" && invisible == false)
        {
            alive = false;
            rigidbody.AddTorque(transform.up * 10 * 2);
            rigidbody.AddTorque(transform.right * 10 * 2);

            Debug.Log("You have died...");

            playerSounds.clip = death;
            playerSounds.Play();
        }
    }
}
