using System;
using UnityEngine;

public class ThrowingBomb : MonoBehaviour
{
    [SerializeField] private Transform _placeDropBomb;
    [SerializeField] private Bomb _bomb;

    private Vector3 _target;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bomb newBomb = Instantiate(_bomb, _placeDropBomb.position, Quaternion.identity);
        }

    }
}
