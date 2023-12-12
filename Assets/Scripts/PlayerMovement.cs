using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using ColorUtility = UnityEngine.ColorUtility;

public class PlayerController : MonoBehaviour
{
    //v�rider der kan �ndre i selve unity 
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

    //en bool er bare en true eller false statment fx er den p� jorden eller ej
    public bool isGrounded;

    //v�rdi til knockback inde i unity 
    public float knockbackForce = 5f;


 
    void Start()
    {
        //Diffinere Rigidboody 2D til rb fra component p� player 
        rb = GetComponent<Rigidbody2D>();

        //Diffinere spriteRenderer til spriteRenderer fra component p� player 
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (collision.gameObject.CompareTag("Player 1") && gameObject.CompareTag("Player 2"))
        {
            // Calculate the knockback direction
            Vector2 knockbackDirection = transform.position - collision.transform.position;

            // Apply the knockback force to both players
            rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);

        }
        else if (collision.gameObject.CompareTag("Player 2") && gameObject.CompareTag("Player 1"))
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

    private SpriteRenderer spriteRenderer;

    public void ChangeColor(string colorCode)
    {
        // Lave farve valg om til HtML format og hvis det ikke bliver til en farve som vi har valgt bliver den hvid
        Color newColor = ColorUtility.TryParseHtmlString(colorCode, out Color parsedColor) ? parsedColor : Color.white;

        // Bliver til en variable som hedder newColor og giver den endelige farve.
        spriteRenderer.color = newColor;
    }
}
