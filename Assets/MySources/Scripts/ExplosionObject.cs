using UnityEngine;
using UnityEngine.AI;

public class ExplosionObject : MonoBehaviour
{
    private NavMeshObstacle navMeshObstacle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
            enemy.Die();

        if (other.gameObject.TryGetComponent(out Player player))
            player.Die();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            Debug.Log("IsCollision");
    }
}
