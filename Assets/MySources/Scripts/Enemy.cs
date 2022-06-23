using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;

    public void Die() =>
        Destroy(gameObject);
    
    public void DieWithEffect()
    {
        ParticleSystem effect = Instantiate(_deathEffect, gameObject.transform.position, Quaternion.identity);
        effect.Play();
        Destroy(effect, 6f);
        Die();
    }
}
