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

    public string entityName = "Unknown";
    public string description = "An unknown cell. Beware!";
    public int dnaCost = 3;

    public Faction faction;
    public int hp =10;
    public int maxHp = 10;
    public int damage = 1;
    public float resistance = 0;
    public float attackspeed = 1;
    public float projectileSpeed = 2;
    public float size = 0.2f;
    public float moveSpeed = 0.5f;

    public bool isActive = false;

    public UnityEvent deathEvent;
    public UnityEvent damageEvent;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
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
                if(deathEvent != null)
                {
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

}
