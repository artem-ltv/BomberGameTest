using System.Collections;
using UnityEngine;

public class ExplosionObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private float _delayDisableCollider;

    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        Instantiate(_explosionEffect, new Vector3(gameObject.transform.position.x, 2.1f, gameObject.transform.position.z), Quaternion.identity);
        StartCoroutine(DisableCollider(_delayDisableCollider));
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.TryGetComponent(out Enemy enemy))
            enemy.Die();

        if (other.gameObject.TryGetComponent(out Player player))
            player.Die();
    }

    private IEnumerator DisableCollider(float delay)
    {
        yield return new WaitForSeconds(delay);
        _collider.enabled = false;
    } 
}
