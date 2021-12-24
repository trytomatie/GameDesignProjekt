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

    public Faction faction;

    public int hp =10;
    public int maxHp = 10;
    public int damage = 1;
    public float resistance = 0;

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


    public void ApplyDamage(int damage)
    {
        damageEvent.Invoke();
        hp -= Mathf.RoundToInt(damage * (1 - resistance));
    }

    public int Hp 
    { 
        get => hp;
        set 
        {
            deathEvent.Invoke();
            hp = value;
        }
    }
}
