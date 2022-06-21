using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private Player _player;
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindObjectOfType<Player>();
    }
    

    private void Update() =>  
        _navMeshAgent.SetDestination(_player.transform.position);
    
}
