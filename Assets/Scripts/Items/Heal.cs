using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int _healAmount = 10;
    [SerializeField] BoxCollider2D _collider;
    [SerializeField] private LifeController _lifeController;

    // Start is called before the first frame update
    void Start()
    {
        _collider = FindFirstObjectByType<BoxCollider2D>();
        _lifeController = FindAnyObjectByType<LifeController>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($" Ti sei curato di {_healAmount}.");
        _lifeController.TakeHeal(_healAmount);
        Destroy(this.gameObject);
    }
}
