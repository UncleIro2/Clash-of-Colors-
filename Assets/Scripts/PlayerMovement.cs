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

    //værdi til knockback inde i unity 
    public float knockbackForce = 5f;



    //Diffinere rb til Rigidboody 2D fra component på player 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Giver groudnCheck en funktion 
        isGrounded = groundCheck();

        //Movement input til player 
        if (Input.GetKey(left))
        {
            rb.AddForce(new Vector2(-moveSpeed, 0));
        }
        else if (Input.GetKey(right))
        {
            rb.AddForce(new Vector2(moveSpeed, 0));
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rb.AddForce(new Vector2(0,100*jumpForce));
        }
  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player 1") && GetComponent("Player 2"))
        {
            // Calculate the knockback direction
            Vector2 knockbackDirection = transform.position - collision.transform.position;

            // Apply the knockback force to both players
            rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
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
