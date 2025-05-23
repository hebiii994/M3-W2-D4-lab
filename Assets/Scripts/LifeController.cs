using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    
   public void TakeDamage( int damage )
    {
        if (damage < 0)
        {
            damage = 0;
        }
        _health -= damage;
        Debug.Log($"la sua salute attuale è di {_health} hp");

        if (_health <= 0)
        {
            Debug.Log("Il giocatore è stato sconfitto.");
            Object.Destroy(this);
        }
    }

    public void TakeHeal( int amount )
    {
        if (amount < 0)
        {
            amount = 0;
        }
        if (_health == 100) 
        {
            amount = 0;
            Debug.Log("Vita al massimo");
        }
        _health += amount;
        Debug.Log($"Il giocatore è stato curato di {amount} hp");
        Debug.Log($"la sua salute attuale è di {_health} hp");

    }
   
}
