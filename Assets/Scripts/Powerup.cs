using System.Collections;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //coledown time 
    public float cooldownTime = 1.0f;
    private bool isCooldown = false;

    private void Start()
    {
        //coledown time i starten n�r objektet ikke er der 
        StartCoroutine(EnableAndDisable(10f));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //K�rer rotinen 
        if (!isCooldown)
        {
            StartCoroutine(EnableAndDisable(cooldownTime));

        }
        if (other.gameObject.CompareTag("Player 1"))
        {
            // Lader dette script p�virke playercontroller n�r der bliver collided med GameObject
            PlayerController PlayerController = other.gameObject.GetComponent<PlayerController>();

            // Checker for komponenter i playercontroller
            if (PlayerController != null)
            {
                // Kan �ndre p� movespeed nu
                PlayerController.moveSpeed = 5;

                //�ndre p� farven
                PlayerController.ChangeColor("#FAA0A0");
            }

        }
        if (other.gameObject.CompareTag("Player 2"))
        {
            // Lader dette script p�virke playercontroller n�r der bliver collided med GameObject
            PlayerController PlayerController = other.gameObject.GetComponent<PlayerController>();

            // Checker for komponenter i playercontroller
            if (PlayerController != null)
            {
                // Kan �ndre p� movespeed nu
                PlayerController.moveSpeed = 5;

                //�ndre p� farven
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

        //t�nder for obejektet
        Debug.Log("Enabling object");
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;



        isCooldown = false;
    }
}
