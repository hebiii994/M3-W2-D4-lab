using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private Rigidbody2D _rb;
    private Vector2 _dir;
    private Vector2 _dirNorm;
    private int _coinCollected = 0;



    // Start is called before the first frame update
    void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        float sqrLenght = _dir.sqrMagnitude;
        if (sqrLenght > 1)
        {
            _dirNorm /= Mathf.Sqrt(sqrLenght);
        }
        _dir = _dirNorm;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        _dir = new Vector2(h, v);

        
        
        _rb.MovePosition(_rb.position + _dir * (_speed * Time.fixedDeltaTime));
    }

    public int CollectCoin(int coinCollected)
    {
        _coinCollected++;
        Debug.Log($"monete raccolte: {_coinCollected}");
        return _coinCollected;
    }
}
