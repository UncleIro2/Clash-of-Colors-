using System.Collections;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //coledown time 
    public float cooldownTime = 1.0f;
    private bool isCooldown = false;

    private void Start()
    {
        StartCoroutine(EnableAndDisable(10f));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Kører rotinen 
        if (!isCooldown)
        {
            StartCoroutine(EnableAndDisable(cooldownTime));

        }
        if (other.gameObject.CompareTag("Player 1"))
        {
            // Get the Script2 component from the collided GameObject
            PlayerController PlayerController = other.gameObject.GetComponent<PlayerController>();

            // Check if the Script2 component is found
            if (PlayerController != null)
            {
                // Modify the variable in Script2
                PlayerController.moveSpeed = 7;
            }
        }
        if (other.gameObject.CompareTag("Player 2"))
        {
            // Get the Script2 component from the collided GameObject
            PlayerController PlayerController = other.gameObject.GetComponent<PlayerController>();

            // Check if the Script2 component is found
            if (PlayerController != null)
            {
                // Modify the variable in Script2
                PlayerController.moveSpeed = 5;
            }
        }
    }

    IEnumerator EnableAndDisable(float cooldown)
    {
        isCooldown = true;
       
        //fjerner objektet 
        Debug.Log("Disabling object");
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(cooldown);

        //tænder for obejektet
        Debug.Log("Enabling object");
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;



        isCooldown = false;
    }
}
