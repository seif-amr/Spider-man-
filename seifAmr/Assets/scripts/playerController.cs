using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float movespeed;
    public float jumpheight;
    public bool isfacingright;
    public KeyCode spacebar;
    public KeyCode L;
    public KeyCode R;
    public Transform groundcheck;
    public float groundcheckradius;
    public LayerMask whatisground;
    private bool grounded;
    private Animator anim;
    public Transform firepoint;
    public GameObject bullet;
    public KeyCode s;
    // Start is called before the first frame update
    void Start()
    {
        isfacingright = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(s))
        {
            Instantiate(bullet, firepoint.position, firepoint.rotation);

        }
        if (Input.GetKeyDown(spacebar) && grounded)
        {
            Jump();

        }
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-movespeed, GetComponent<Rigidbody2D>().velocity.y);
            if (isfacingright)
            {
                flip();
                isfacingright = false;
            }
        }
        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, GetComponent<Rigidbody2D>().velocity.y);
            if (!isfacingright)
            {
                flip();
                isfacingright = true;
            }
        }
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);
    }
    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpheight);

    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius, whatisground);
    }
}
