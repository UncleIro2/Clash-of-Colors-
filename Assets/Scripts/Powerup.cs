using System.Collections;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //coledown time 
    public float cooldownTime = 1.0f;
    private bool isCooldown = false;

    private void Start()
    {
        //coledown time i starten når objektet ikke er der 
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
            // Lader dette script påvirke playercontroller når der bliver collided med GameObject
            PlayerController PlayerController = other.gameObject.GetComponent<PlayerController>();

            // Checker for komponenter i playercontroller
            if (PlayerController != null)
            {
                // Kan ændre på movespeed nu
                PlayerController.moveSpeed = 5;

                //Ændre på farven
                PlayerController.ChangeColor("#FAA0A0");
            }

        }
        if (other.gameObject.CompareTag("Player 2"))
        {
            // Lader dette script påvirke playercontroller når der bliver collided med GameObject
            PlayerController PlayerController = other.gameObject.GetComponent<PlayerController>();

            // Checker for komponenter i playercontroller
            if (PlayerController != null)
            {
                // Kan ændre på movespeed nu
                PlayerController.moveSpeed = 5;

                //Ændre på farven
                PlayerController.ChangeColor("#DFFF00");

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
