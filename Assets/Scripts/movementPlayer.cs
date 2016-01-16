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
    public RaycastHit rHit;
    public float raycastMaxRange;
    public GameObject drop;
    public LineRenderer lR;
    public Camera cam;
    public float amountOfPoop;

    void Start()
    {
        lR = gameObject.GetComponent<LineRenderer>();
        lR.SetColors(Color.red, Color.green);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    void Update()
    {
        if (amountOfPoop == 3)
        {
            Application.LoadLevel();
        }


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

        if (Input.GetKey(KeyCode.Mouse0))
        {
            lR.SetVertexCount(2);
            

            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 2.5f;

            Debug.DrawRay(transform.position, mousePos - transform.position);
            lR.SetPosition(0, transform.position);
            lR.SetPosition(1, mousePos);



            RaycastHit2D hit = (Physics2D.Raycast(transform.position, mousePos - transform.position, Vector2.Distance(transform.position, mousePos)));
            if (hit.transform.tag == "Destroyable")
            {
                Destroy(hit.collider.gameObject);
                Instantiate(drop, hit.transform.position, Quaternion.identity);
                print(hit.transform.tag + " Just got hit");
            }
        }

        

        else
        {
            lR.SetVertexCount(0);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "poo")
        {
            Destroy(col.collider.gameObject);
            print("U got mail *ding*");
            amountOfPoop++;
        }
    }
}
