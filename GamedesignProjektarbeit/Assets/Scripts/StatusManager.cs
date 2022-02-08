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
    public int dnaCost = 5;
    public int upgradeCost = 5;

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
    private int stamina = 50;
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

    /// <summary>
    /// Regenerates Stamina
    /// </summary>
    private void StaminaRegen()
    {
        if(Stamina < maxStamina)
        {
            Stamina+=2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Stamina > 10)
        {
            attackSpeedMultiplier = 1;
        }
        else
        {
            attackSpeedMultiplier = 0.5f;
        }

        if(stunValue > 3)
        {
            StunMe();
        }
    }

    /// <summary>
    /// Stuns entity for 3 seconds
    /// </summary>
    private void StunMe()
    {
        StartCoroutine(SetMoveSpeed(moveSpeedMod, 3f));
        moveSpeedMod = 0;
        stunValue = 0;
    }

    /// <summary>
    /// Sets movespeed after a delay
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="delay"></param>
    /// <returns></returns>
    IEnumerator SetMoveSpeed(float amount, float delay)
    {
        yield return new WaitForSeconds(delay);
        moveSpeedMod = amount;
    }

    /// <summary>
    /// Base Death event 
    /// </summary>
    public void BaseDeathEvent()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Apply damage to me
    /// </summary>
    /// <param name="damage"></param>
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
            hp = value;
            if (hp <= 0)
            {
                if(deathEvent != null && !dead)
                {
                    dead = true;
                    deathEvent.Invoke();  
                }               
            }

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

    public int Stamina { get => stamina; set
        {
            stamina = Mathf.Clamp(value, 0, maxStamina);
        }
    }
}
