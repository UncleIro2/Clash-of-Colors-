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
            PlayerController.doublejump = false;
            PlayerController.moveSpeed = 3.5f;
            PlayerController.flycontroller = false;


            if (randomIndex == 1)
            {
                    
                // Kan �ndre p� movespeed nu
                PlayerController.moveSpeed = 5.5f;

                //�ndre p� farven
                PlayerController.ChangeColor("#FFCDCD");
                PlayerController.doublejumpcontroller = false;

            }

            else if (randomIndex == 2)
            {               
                    
                // Lader dig dashe 
                PlayerController.dashController = true;
                    
                    //�ndre p� farven
                PlayerController.ChangeColor("#FF8E8E");
                PlayerController.doublejumpcontroller = false;

            }

            else if (randomIndex == 3)
            {
                // reset til ingen powerups
                PlayerController.dashController = false;
                PlayerController.moveSpeed = 3.5f;
                PlayerController.flycontroller = false;
                PlayerController.doublejumpcontroller = false;


                //�ndre p� farven
                PlayerController.ChangeColor("#FF0000");
            }
           
            else if (randomIndex == 4)
            {

                // Lader dig dashe 
                PlayerController.doublejumpcontroller = true;

                //�ndre p� farven
                PlayerController.ChangeColor("#FF5555");

            }
            else if (randomIndex == 5)
            {

                // Lader dig dashe 
                PlayerController.flycontroller = true;

                //�ndre p� farven
                PlayerController.ChangeColor("#B82F2F");
                PlayerController.doublejumpcontroller = false;

            }
        }



        if (other.gameObject.CompareTag("Player 2"))
        {
            // Lader dette script p�virke playercontroller n�r der bliver collided med GameObject
            PlayerController PlayerController = other.gameObject.GetComponent<PlayerController>();

            int randomIndex = Random.Range(1, 6);


            PlayerController.dashController = false;
            PlayerController.moveSpeed = 4f;
            PlayerController.flycontroller = false;
            PlayerController.doublejump = false;




            if (randomIndex == 1)
            {

                // Kan �ndre p� movespeed nu
                PlayerController.moveSpeed = 5;

                //�ndre p� farven
                PlayerController.ChangeColor("#D3D7FF");
                PlayerController.doublejumpcontroller = false;


            }

            else if (randomIndex == 2)
            {

                // Lader dig dashe 
                PlayerController.dashController = true;

                //�ndre p� farven
                PlayerController.ChangeColor("#A0AAFF");
                PlayerController.doublejumpcontroller = false;

            }

            else if (randomIndex == 3)
            {
                // reset til ingen powerups
                PlayerController.dashController = false;
                PlayerController.moveSpeed = 4f;
                PlayerController.doublejumpcontroller = false;
                PlayerController.flycontroller = false;




                //�ndre p� farven
                PlayerController.ChangeColor("#001BFF");
            }

            else if (randomIndex == 4)
            {

                // Lader dig dublejump 
                PlayerController.doublejumpcontroller = true;

                //�ndre p� farven
                PlayerController.ChangeColor("#6273FF");

            }
            else if (randomIndex == 5)
            {

                // Lader dig dashe 
                PlayerController.flycontroller = true;
                PlayerController.doublejumpcontroller = false;

                //�ndre p� farven
                PlayerController.ChangeColor("#323FB0");

            }
        } 
        
    }

    public IEnumerator EnableAndDisable(float cooldown)
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
