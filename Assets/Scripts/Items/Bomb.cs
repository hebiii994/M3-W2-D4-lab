using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage = 25;
    [SerializeField] BoxCollider2D _collider;
    [SerializeField] private LifeController _lifeController;
    

    private void Start()
    {
        _collider = FindFirstObjectByType<BoxCollider2D>();
        _lifeController = FindAnyObjectByType<LifeController>();
        
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($" Hai subito {_damage} di danno.");
        _lifeController.TakeDamage(_damage);
        Destroy(this.gameObject);
    }

    
}
