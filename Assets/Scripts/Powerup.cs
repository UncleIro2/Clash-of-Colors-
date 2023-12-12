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

                int randomIndex = Random.Range(1, 3);

                if (randomIndex == 1)
                {
                    
                    // Kan ændre på movespeed nu
                    PlayerController.moveSpeed = 5;

                    //Ændre på farven
                    PlayerController.ChangeColor("#FAA0A0");
                    
                }

                else if (randomIndex == 2)
                {               
                    
                    // Lader dig dashe 
                    PlayerController.dashController = true;
                    
                     //Ændre på farven
                    PlayerController.ChangeColor("#702963");
                    
                }
            }



        if (other.gameObject.CompareTag("Player 2"))
        {
            // Lader dette script påvirke playercontroller når der bliver collided med GameObject
            PlayerController PlayerController = other.gameObject.GetComponent<PlayerController>();

            int randomIndex = Random.Range(1, 3);

            if (randomIndex == 1)
            {
                
                // Kan ændre på movespeed nu
                PlayerController.moveSpeed = 5;

                //Ændre på farven
                PlayerController.ChangeColor("#DFFF00");

                
            }

            else if (randomIndex == 2)
            {
               
                // Lader dig dashe 
                PlayerController.dashController = true;

                //Ændre på farven
                PlayerController.ChangeColor("#C4B454");
                
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
