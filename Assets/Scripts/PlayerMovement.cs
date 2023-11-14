using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //værider der kan ændre i selve unity 
    public float moveSpeed;
    public float jumpForce;

    //deffineres til player 1 movement
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    //navgive rigidbody fra player til rb i scripted 
    private Rigidbody2D rb;

    //det er en layer som man skal give til sinde paltforme 
    public LayerMask whatIsGround;

    //en bool er bare en true eller false statment fx er den på jorden eller ej
    public bool isGrounded;



    //Diffinere rb til Rigidboody 2D fra component på player 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Giver groudnCheck en funktion 
        //isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckcRadius, whatIsGround);

        isGrounded = groundCheck();

        //Movement input til player 1
        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


    }

    
    bool groundCheck()
    {
        //selve groundCheck ved brug af raycasthit        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.55f, whatIsGround);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
