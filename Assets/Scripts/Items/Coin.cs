using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinNumber = 0;
    [SerializeField] BoxCollider2D _collider;   
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        _collider = Object.FindFirstObjectByType<BoxCollider2D>();
        _playerController = Object.FindFirstObjectByType<PlayerController>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _coinNumber++;
        _playerController.CollectCoin(_coinNumber);
        
        Destroy(this.gameObject);
    }
}
