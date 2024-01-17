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

            int randomIndex = Random.Range(1,6);

            PlayerController.dashController = false;
            PlayerController.doublejumpcontroller = false;
            PlayerController.moveSpeed = 4f;
            PlayerController.flycontroller = false;


            if (randomIndex == 1)
            {
                    
                // Kan �ndre p� movespeed nu
                PlayerController.moveSpeed = 6;

                //�ndre p� farven
                PlayerController.ChangeColor("#FAA0A0");
                    
            }

            else if (randomIndex == 2)
            {               
                    
                // Lader dig dashe 
                PlayerController.dashController = true;
                    
                    //�ndre p� farven
                PlayerController.ChangeColor("#702963");
                    
            }

            else if (randomIndex == 3)
            {
                // reset til ingen powerups
                PlayerController.dashController = false;
                PlayerController.moveSpeed = 4f;
                PlayerController.dashController = false;
                PlayerController.flycontroller = false;


                //�ndre p� farven
                PlayerController.ChangeColor("#FF0000");
            }
           
            else if (randomIndex == 4)
            {

                // Lader dig dashe 
                PlayerController.doublejumpcontroller = true;

                //�ndre p� farven
                PlayerController.ChangeColor("#EC5800");

            }
            else if (randomIndex == 5)
            {

                // Lader dig dashe 
                PlayerController.flycontroller = true;

                //�ndre p� farven
                PlayerController.ChangeColor("#000000");

            }
        }



        if (other.gameObject.CompareTag("Player 2"))
        {
            // Lader dette script p�virke playercontroller n�r der bliver collided med GameObject
            PlayerController PlayerController = other.gameObject.GetComponent<PlayerController>();

            int randomIndex = Random.Range(1, 6);


            PlayerController.dashController = false;
            PlayerController.moveSpeed = 4f;
            PlayerController.doublejumpcontroller = false;
            PlayerController.flycontroller = false;



            if (randomIndex == 1)
            {

                // Kan �ndre p� movespeed nu
                PlayerController.moveSpeed = 5;

                //�ndre p� farven
                PlayerController.ChangeColor("#DFFF00");


            }

            else if (randomIndex == 2)
            {

                // Lader dig dashe 
                PlayerController.dashController = true;

                //�ndre p� farven
                PlayerController.ChangeColor("#C4B454");

            }

            else if (randomIndex == 3)
            {
                // reset til ingen powerups
                PlayerController.dashController = false;
                PlayerController.moveSpeed = 4f;
                PlayerController.doublejumpcontroller = false;
                PlayerController.flycontroller = false;



                //�ndre p� farven
                PlayerController.ChangeColor("#00FF00");
            }

            else if (randomIndex == 4)
            {

                // Lader dig dashe 
                PlayerController.doublejumpcontroller = true;

                //�ndre p� farven
                PlayerController.ChangeColor("#40B5AD");

            }
            else if (randomIndex == 5)
            {

                // Lader dig dashe 
                PlayerController.flycontroller = true;

                //�ndre p� farven
                PlayerController.ChangeColor("#FFFFFF");

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
