using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float interval = 0.3f;
    [SerializeField] float rangeX = 20f;
    [SerializeField] float rangeY = 20f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void ShowEnemy()
    {
        float randomX = Random.Range(-rangeX, rangeX);
        float randomY = Random.Range(-rangeY, rangeY);
        Vector3 pos = transform.position + new Vector3(randomX, randomY, 0f);
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
           
                ShowEnemy();
          yield return new WaitForSeconds(interval);
        }
    }
}
