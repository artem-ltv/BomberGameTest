using UnityEngine;

public class GameWinning : MonoBehaviour
{
    [SerializeField] private WinningRoom _winningRoom;
    [SerializeField] private EnemySpawner _enemySpawner;

    private Enemy[] _livingEnemies;

    private void OnEnable()
    {
        _winningRoom.EnteringWinningRoom += Winning;
    }
    private void OnDisable()
    {
        _winningRoom.EnteringWinningRoom -= Winning;
    }

    private void Winning()
    {
        Destroy(_enemySpawner);
        _livingEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (var item in _livingEnemies)
            item.DieAfterWinning();
    }
}