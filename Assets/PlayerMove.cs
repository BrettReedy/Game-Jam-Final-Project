using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 200;
    public float fallSpeed = 0.01f;
    Vector2 move;
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        rb.gravityScale = 0;
    }
   

    void FixedUpdate()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector3.left, 0.25f);
        if (hit.Length > 0)
        {
            foreach (RaycastHit2D hitI in hit)
            {
                if (hitI.collider.gameObject != gameObject)
                {
                    move.x = 0.05f;
                    print(hitI.collider.gameObject.name);
                }
            }
        }

        hit = Physics2D.RaycastAll(transform.position, Vector3.right, 0.25f);
        if (hit.Length > 0)
        {
            foreach (RaycastHit2D hitI in hit)
            {
                if (hitI.collider.gameObject != gameObject)
                {
                    move.x = -0.05f;
                    print(hitI.collider.gameObject.name);
                }
            }
        }
        move.y -= (fallSpeed * Time.deltaTime);
        rb.MovePosition(rb.position + (move * speed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print("HELP");
    }
    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = 0;
    }
}
