using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _pointsSpawn;
    [SerializeField] Enemy _enemy;
    [SerializeField] private float _delaySpawn;

    private void Start() =>
        StartCoroutine(SpawnEnemy(_enemy, _delaySpawn));
    

    private IEnumerator SpawnEnemy(Enemy enemy, float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            int indexPointSpawn = Random.Range(0, _pointsSpawn.Length);
            Instantiate(enemy, _pointsSpawn[indexPointSpawn].position, Quaternion.identity);
        }
    }
}
