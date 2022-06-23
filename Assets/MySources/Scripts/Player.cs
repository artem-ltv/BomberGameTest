using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction Dying;

    [SerializeField] AudioSource _loseAudio;

    public void Die()
    {
        Dying?.Invoke();
        _loseAudio.Play();
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
