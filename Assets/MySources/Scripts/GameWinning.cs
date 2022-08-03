using UnityEngine;

public class GameWinning : MonoBehaviour
{
    [SerializeField] private WinningRoom _winningRoom;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameObject _winningPanel;
    [SerializeField] private AudioSource _winningAudio;

    private Enemy[] _livingEnemies;

    private void OnEnable() =>
        _winningRoom.EnteringWinningRoom += Winning;
    
    private void OnDisable() =>
        _winningRoom.EnteringWinningRoom -= Winning;
    

    private void Winning()
    {
        _winningPanel.SetActive(true);
        _winningAudio.Play();
        Cursor.lockState = CursorLockMode.None;
        Destroy(_enemySpawner);
        _livingEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (var item in _livingEnemies)
            item.DieWithEffect();
    }

}
