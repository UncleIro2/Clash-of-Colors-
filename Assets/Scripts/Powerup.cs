using System.Collections;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //coledown time 
    public float cooldownTime = 1.0f;
    private bool isCooldown = false;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        //Kører rotinen 
        if (!isCooldown)
        {
            StartCoroutine(EnableAndDisable(cooldownTime));
        }
    }

    IEnumerator EnableAndDisable(float cooldown)
    {
        isCooldown = true;
       
        //fjerner objektet 
        Debug.Log("Disabling object");
        gameObject.GetComponent<SpriteRenderer>().enabled = false; 
        
        yield return new WaitForSeconds(cooldown);

        //tænder for obejektet
        Debug.Log("Enabling object");
        gameObject.GetComponent<SpriteRenderer>().enabled = true;



        isCooldown = false;
    }
}
