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
    //værider der kan ændre i selve unity 
    public float moveSpeed;
    public float jumpForce;

    //deffineres til player 1 movement
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode dash;

    //navgive rigidbody fra player til rb i scripted 
    private Rigidbody2D rb;

    //det er en layer som man skal give til sinde paltforme 
    public LayerMask whatIsGround;

    //en bool er bare en true eller false statment fx er den på jorden eller ej
    public bool isGrounded;

    //værdi til knockback inde i unity 
    public float knockbackForce = 5f;

    //Variabler til dash 
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    //Variabel for at altid vende mod højre
    private bool isFacingRight = true;

    public bool hasCollided = false;




    void Start()
    {
        //Diffinere Rigidboody 2D til rb fra component på player 
        rb = GetComponent<Rigidbody2D>();

        //Diffinere spriteRenderer til spriteRenderer fra component på player 
        spriteRenderer = GetComponent<SpriteRenderer>();
    }





    void Update()
    {
        //Giver groudnCheck en funktion 
        isGrounded = groundCheck();

        //Movement input til player 
        if (Input.GetKey(left))
        {
            rb.AddForce(new Vector2(-moveSpeed * Time.deltaTime * 500, 0));
        }
        else if (Input.GetKey(right))
        {
            rb.AddForce(new Vector2(moveSpeed * Time.deltaTime * 500, 0));
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rb.AddForce(new Vector2(0,100*jumpForce));
        }
        
        //Dash input 
        if (Input.GetKeyDown(dash) && canDash)
        {
           StartCoroutine(Dash());
        }

        //Sørge gor at flippe spilleren mod højre 
        Flip();

    }




    //Selve koden for at vende mod højre
    private void Flip()
    {
        if (isFacingRight && rb.velocity.x < 0f || !isFacingRight && rb.velocity.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }







    //Knockback
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




    //Sørge for at man kan dashe igen efter coledown
    private void FixedUpdate()
    {

        if (isDashing)
        {
            return;
        }
    }

    private IEnumerator Dash()
    {
        if (hasCollided)
        {

            //Koden for at dashe 
            canDash = false;
            isDashing = true;
            float originalGravity = 5f;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
            //tr.emitting = true;
            yield return new WaitForSeconds(dashingTime);
            //tr.emitting = false;
            rb.gravityScale = originalGravity;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;
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
