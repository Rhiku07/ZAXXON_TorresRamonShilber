
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemySpawner;
    [SerializeField] GameObject enemySpawnPrefab;
    [SerializeField] float interval;
     float maxX = 10f;
     float maxY = 10f;
    

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        interval = 0.3f;
    }

    void Update()
    {
       
    }
    void ShowEnemy()
    {
        float randomX = Random.Range(maxX, -maxX);
        float randomY = Random.Range(maxY, -maxY);
        Vector3 pos = new Vector3(randomX, randomY, transform.position.z);
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
   IEnumerator SpawnEnemy()
    {
        while (true)
        {
            {
                ShowEnemy();
            }
            yield return new WaitForSeconds(interval);
        }
    }
        
  
}

