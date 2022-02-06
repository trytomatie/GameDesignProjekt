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
    public GameObject gameOverScreen;
    
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


    public void OrganTakeDamage(float damage)
    {
        if (alive)
        {

            organAnimator.SetTrigger("getDamage"); // spiele die Animation get Damage ab
            //Ziehe den Schaden vom Aktuellen Leben ab
            currentHealth = currentHealth - damage;
            //berechne den Prozentwert Für die Healthbar
            healthPercantage = currentHealth / startHealth * 100;
            GameManager.instance.hpBar.fillAmount = healthPercantage;
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
            gameOverScreen.SetActive(true);
            
        }
        else 
        { 
            alive = true;
        }
        //ein Return falls mal das ganze vom Gamemanager oder so aufgerufen werden soll
        return alive;
    }




}
