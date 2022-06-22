using UnityEngine;
using UnityEngine.Events;

public class WinningRoom : MonoBehaviour
{
    public event UnityAction EnteringWinningRoom;

    [SerializeField] private ParticleSystem _firework;
    [SerializeField] private Transform _fireworkPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player player))
        {
            ParticleSystem effect = Instantiate(_firework, _fireworkPoint.position, Quaternion.identity);
            effect.Play();
            EnteringWinningRoom?.Invoke();
        }
    }
}