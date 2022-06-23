using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction Dying;
    public void Die()
    {
        Dying?.Invoke();
        Debug.Log("PlayerDie");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            Die();
        }
    }
}
