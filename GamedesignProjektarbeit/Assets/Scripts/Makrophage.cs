using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// By Markus Schwalb
/// </summary>
public class Makrophage : BasicTurretAI
{
    // public float coolDown;


    private Animator macrophageAnimator;
    private float timerSetTime;
    public bool attackAble;

    // Start is called before the first frame update
    void Start()
    {
        myStatus = GetComponent<StatusManager>();
        macrophageAnimator = GetComponent<Animator>();
        makrophageAudioSource = GetComponent<AudioSource>();
        attackAble = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!attackAble)        //falls die Makrophage im cooldown ist fuehre aus
        {
            CheckCoolDown();
        }

        upgradeText.text = myStatus.level.ToString();
    }

    /// <summary>
    /// Checks Cooldown of attack
    /// </summary>
    private void CheckCoolDown()
    {
        if (Time.time >= timerSetTime+ Mathf.Clamp(1 / myStatus.Attackspeed, 0.01f, 100f)) //wenn der Cooldown vorueber kann die Macrophage wieder angreifen
        {
            attackAble = true;
        }
    }

    
    private void OnTriggerStay2D(Collider2D other)      //on trigger stay um in der Teorie beim 2ten schlag alle in der Triggerzone zu Attackieren
    {
        if (other.gameObject.CompareTag("Enemy"))   //falls ein gegnerrisches Bakterium den Trigger Collider eindring
        {
            //trigger macrophage
            //print("macrophage Trigger");

            if (attackAble==true)       //falls der CooldownAbgelaufen ist und die Zelle wieder Angreifen kann
            {
                GetComponent<StatusManager>().Stamina -= 5;
                macrophageAnimator.SetTrigger("Attack");
                makrophageAudioSource.PlayOneShot(attackSound, 0.5f);
                var statusManagerScript = other.gameObject.GetComponent<StatusManager>();

                statusManagerScript.ApplyDamage(myStatus.damage);
                timerSetTime = Time.time;       //die Zeit an dem der Cooldown gestartet ist
                attackAble = false;             //fuers naechste mal kann nicht mehr angreifen 
                print(Time.time);
            }
            
        }
    }

}
