using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ : MonoBehaviour
{

    //Health variablen
    public float startHealth;
    public bool alive;

    public float currentHealth;
    private float healthPercantage;

    private Animator organAnimator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Hole die Componente Animator die auf dem Organ Liegt setz die AnimationsVariable is alive auf true (Organ lebt)
        organAnimator = GetComponent<Animator>();
        organAnimator.SetBool("isAlive", true);

        //setze das Aktuelle Leben auf den Startwert des Lebens
        currentHealth = startHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("collision");
        //Wenn ein gegner in reichweite kommt soll er Schaden nehmen
        if (other.gameObject.CompareTag("Enemy"))
        {
            organAnimator.SetTrigger("getDamage");
            //bekomme die feindlichen Bakterie und den Animator 
            GameObject enemyBakteria = other.gameObject;
            Animator enemyAnimator = other.GetComponent<Animator>();
            
            //mache das der gegner angreift
            enemyAnimator.SetBool("isAttacking", true);
            TakeDamage(10);
            //zerstöre das Andere GameObject nach dem ende seiner Animation
            Destroy(other.gameObject, 2f);
            
            //print(enemyAnimator.GetCurrentAnimatorClipInfo(0).Length);
            
        }
    }

    public void TakeDamage(float damage)
    {
        if (alive)
        {
            //Ziehe den Schaden vom Aktuellen Leben ab
            currentHealth = currentHealth - damage;
            //berechne den Prozentwert Für die Healthbar
            healthPercantage = currentHealth / startHealth * 100;
            CheckAlive();
        }
        
    }

    public bool CheckAlive()
    {
        //Überprüfe ob das Organ noch Leben hat und setze die Variable Alife dem entsprechend
        if (currentHealth < 0)
        {
            alive = false;
            organAnimator.SetBool("isAlive", false);
            //game Over
        }
        else 
        { 
            alive = true;
        }
        //ein Return falls mal das ganze vom Gamemanager oder so aufgerufen werden soll
        return alive;
    }




}
