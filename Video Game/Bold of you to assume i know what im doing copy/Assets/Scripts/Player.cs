using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float speed;
	public int health = 3;
    public int upForce = 25;
    public int count = 0;

	private Animator anim;
    private Rigidbody2D rb2d;
    private bool isGrounded;

	private void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * 4f * Time.deltaTime, 0f, 0f);

        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
 
            transform.position += Vector3.up * Time.deltaTime * upForce;
        }

        anim.SetFloat("walkspeed", rb2d.velocity.x);
    }

}

