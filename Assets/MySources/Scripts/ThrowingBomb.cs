using System;
using System.Collections;
using UnityEngine;

public class ThrowingBomb : MonoBehaviour
{
    [SerializeField] private Transform _placeDropBomb;
    [SerializeField] private Bomb _bomb;
    [SerializeField] private BombExplosion _bombExplosion;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bomb newBomb = Instantiate(_bomb, _placeDropBomb.position, Quaternion.identity);
            _bombExplosion.LaunchExplosion(newBomb);
        }
    }
}
