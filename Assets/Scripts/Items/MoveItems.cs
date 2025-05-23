using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveItems : MonoBehaviour
{
    [SerializeField] private Coin [] _randomCoins;
    [SerializeField] private Bomb[] _randomBombs;
    [SerializeField] private Heal[] _randomHeal;
    [SerializeField] private float _speedItems = 5f;
    [SerializeField] private float _leftBoundaryX = -10f;
    

    private List<Vector3> _originalCoinPositions;
    private List<Vector3> _originalBombPositions;
    private List<Vector3> _originalHealPositions;

    // Start is called before the first frame update
    void Start()
    {
        _originalCoinPositions = new List<Vector3>();
        _originalBombPositions = new List<Vector3>();
        _originalHealPositions = new List<Vector3>();

        _randomCoins = GetComponentsInChildren<Coin> ();
        _randomBombs = GetComponentsInChildren <Bomb> ();
        _randomHeal = GetComponentsInChildren<Heal> ();

        // memorizzo posizione iniziale coins
        foreach (Coin coin in _randomCoins)
        {
            if (coin != null)
            {
                _originalCoinPositions.Add(coin.transform.position);
            }
        }
        // memorizzo posizione iniziale bombs
        foreach (Bomb bomb in _randomBombs)
        {
            if (bomb != null)
            {
                _originalBombPositions.Add(bomb.transform.position);
            }
        }

        // memorizzo posizione iniziale heals
        foreach (Heal heal in _randomHeal)
        {
            if (heal != null)
            {
                _originalHealPositions.Add(heal.transform.position);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (_randomCoins.Length == _originalCoinPositions.Count)
        {
            for (int i = 0; i < _randomCoins.Length; i++)
            {
                Coin coin = _randomCoins[i];
                if (coin == null) continue; 

                // Muovi la moneta verso sinistra
                coin.transform.Translate(Vector3.left * _speedItems * Time.deltaTime, Space.World);

                // Controlla se la moneta è uscita dallo schermo a sinistra
                if (coin.transform.position.x < _leftBoundaryX)
                {
                    // Riportala alla sua posizione originale memorizzata
                    coin.transform.position = _originalCoinPositions[i];
                }
            }
        }

        // --- Gestione Movimento e Reset per le BOMBE ---
        if (_randomBombs.Length == _originalBombPositions.Count)
        {
            for (int i = 0; i < _randomBombs.Length; i++)
            {
                Bomb bomb = _randomBombs[i];
                if (bomb == null) continue;

                // Muovi la bomba verso sinistra
                bomb.transform.Translate(Vector3.left * _speedItems * Time.deltaTime, Space.World);

                // Controlla se la bomba è uscita dallo schermo a sinistra
                if (bomb.transform.position.x < _leftBoundaryX)
                {
                    // Riportala alla sua posizione originale memorizzata
                    bomb.transform.position = _originalBombPositions[i];
                }
            }
        }

        // --- Gestione Movimento e Reset per le CURE ---
        if (_randomHeal.Length == _originalHealPositions.Count)
        {
            for (int i = 0; i < _randomHeal.Length; i++)
            {
                Heal healItem = _randomHeal[i];
                if (healItem == null) continue;

                // Muovi l'item di cura verso sinistra
                healItem.transform.Translate(Vector3.left * _speedItems * Time.deltaTime, Space.World);

                // Controlla se l'item di cura è uscito dallo schermo a sinistra
                if (healItem.transform.position.x < _leftBoundaryX)
                {
                    // Riportalo alla sua posizione originale memorizzata
                    healItem.transform.position = _originalHealPositions[i];
                }
            }
        }
    }

   

   
}
