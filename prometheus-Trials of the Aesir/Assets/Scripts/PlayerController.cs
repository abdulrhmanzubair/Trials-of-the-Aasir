using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 18;
    Rigidbody2D rbody;
    Animator anim;

    // Use this for initialization
    void Start()
    {

        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    void FixedUpdate()
    {

        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime;

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("Walk", true);
            
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        rbody.MovePosition(rbody.position + movement_vector);

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
    }
}