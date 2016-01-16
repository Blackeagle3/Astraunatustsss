using UnityEngine;
using System.Collections;

public class movementPlayer : MonoBehaviour
{

    public float moveSpeed;
    private float moveVelocity;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private bool doubleJumped;
    public Camera myCam;
    

    void Start()
    {
        GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    void Update()
    {
        if (grounded)
            doubleJumped = false;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new
            Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new
            Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            doubleJumped = true;
        }

        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.D))

        {
            moveVelocity = moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))

        {
            moveVelocity = -moveSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //Ray2D ray = new Ray2D(new Vector2(transform.position.x, transform.position.y), new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            //RaycastHit2D cast = Physics2D.Raycast(ray.origin, ray.direction);
            //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y), new Vector3(Input.mousePosition.x, Input.mousePosition.y);


           // Camera myCam = GetComponent<Camera>();
        }
    }
}
