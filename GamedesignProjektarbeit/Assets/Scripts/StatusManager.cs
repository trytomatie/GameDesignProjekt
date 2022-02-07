using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// By Christian Scherzer
/// </summary>
public class StatusManager : MonoBehaviour
{
    public enum Faction  {Player,Enemy};
    public Sprite sprite;
    public string entityName = "Unknown";
    public string description = "An unknown cell. Beware!";
    public int dnaCost = 3;

    public Faction faction;
    public int level = 1;
    public int hp =10;
    public int maxHp = 10;
    public int damage = 1;
    public float resistance = 0;
    public float baseAttackspeed;
    public float attackSpeedMultiplier;
    private float attackspeed = 1;
    public float projectileSpeed = 2;
    public float size = 0.2f;
    private float moveSpeed = 0.5f;
    public float baseMoveSpeed = 15;
    public float moveSpeedMod = 1;
    public float moveSpeedPenalty = 0;
    public int stamina = 50;
    [HideInInspector]
    public int maxStamina = 100;

    public int stunValue = 0;

    public bool isActive = false;

    public UnityEvent deathEvent;
    public UnityEvent damageEvent;

    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        // regens 1 Stamina every 3 seconds
        InvokeRepeating("StaminaRegen", 0, 3f); 
    }

    private void StaminaRegen()
    {
        if(stamina < maxStamina)
        {
            stamina++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(stamina > 10)
        {
            attackSpeedMultiplier = 1;
        }
        else
        {
            attackSpeedMultiplier = 0.5f;
        }

        if(stunValue > 3)
        {
            StartCoroutine(SetMoveSpeed(moveSpeedMod, 3f));
            moveSpeedMod = 0;
            stunValue = 0;
        }
    }

    IEnumerator SetMoveSpeed(float amount, float delay)
    {
        yield return new WaitForSeconds(delay);
        moveSpeedMod = amount;
    }

    private void BaseDeathEvent()
    {
        Destroy(gameObject);
    }


    public void ApplyDamage(int damage)
    {
       
        damageEvent.Invoke();
        Hp -= Mathf.RoundToInt(damage * (1 - resistance));
    }

    public int Hp
    {
        get => hp;
        set
        {
            if(value <= 0)
            {
                if(deathEvent != null && !dead)
                {
                    dead = true;
                    deathEvent.Invoke();
                    GameManager.instance.Dna += dnaCost;
                }
                else
                {
                    BaseDeathEvent();
                    GameManager.instance.Dna += dnaCost;
                }
                
            }
            
            hp = value;
        }
    }

    public float Attackspeed { 
        get 
        {
            return baseAttackspeed * attackSpeedMultiplier;
        }
    }

    public float MoveSpeed
    {
        get
        {
            return (baseMoveSpeed - moveSpeedPenalty) * moveSpeedMod;
        }
    }
}
