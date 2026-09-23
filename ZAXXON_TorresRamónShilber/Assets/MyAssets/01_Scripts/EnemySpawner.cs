using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemySpawner;
     float maxX = 10f;
     float maxY = 10f;
     float minX = -10f;
     float minY = -10f;
    void Start()
    {
       
    }

    void Update()
    {
       
    }
    void showEnemy()
    {
        float randomX = Random.Range(maxX, minX);
        float randomY = Random.Range(maxY, minY);
    }
   
        
  
}

