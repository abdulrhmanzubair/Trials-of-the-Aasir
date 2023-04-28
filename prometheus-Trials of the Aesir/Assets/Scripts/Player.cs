using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    float horizontalMove = 0f;
    public Animator animator;
    private Rigidbody2D rb;
    public float Speed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    public void Update()
    {

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Move the Character:
        transform.Translate(Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f, 0f);

        // Flip the Character:
        Vector3 Player = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            Player.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            Player.x = 1;
        }
        transform.localScale = Player;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("Walk", false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Walk", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Walk", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Walk", false);
        }



    }

    
}