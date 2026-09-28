
using System.Collections;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] PlayerManager playerManager;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemySpawner;
    [SerializeField] float interval;
     float maxX = 10f;
     float maxY = 20f;
     float minY = -15;
    

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
        float randomY = Random.Range(maxY, minY);
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

