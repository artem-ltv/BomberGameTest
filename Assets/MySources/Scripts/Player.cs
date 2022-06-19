using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private void Update()
    {
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        //
    }
}
