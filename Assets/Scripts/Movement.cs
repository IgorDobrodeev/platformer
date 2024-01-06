using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public bool isGrounded=false;
    float moveForce=5f;
    private float jumpForce=3.2f;
    private float last=0f;
    private float current=0f;
    private float moveX=0f;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.AddForce((Input.GetAxis("Horizontal")*moveForce*transform.right),ForceMode2D.Force);
        rb.AddForce(transform.up*jumpForce/2000,ForceMode2D.Impulse);
        if(isGrounded == true){
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.up*jumpForce,ForceMode2D.Impulse);
            }
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "ladder")
        {
             rb.AddForce(transform.up*jumpForce/10,ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("spike"))
        {
            transform.position = new Vector3(0,0,0);
        }
        if (collision.gameObject.CompareTag("platform"))
        {
            if (last == 0) {
                isGrounded = true;
                last = collision.gameObject.transform.position.x;
            }
            else {
                isGrounded = true;
                current = collision.gameObject.transform.position.x;
                moveX = last - current;
                transform.position -= new Vector3(moveX,0,0);
                last = current;
            }

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "trampoline"){
             rb.AddForce(transform.up*jumpForce*2.5f,ForceMode2D.Impulse);   
        }
    }
    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
        if (last != 0) {
            last = 0;
            isGrounded = false;
        }
    }
}