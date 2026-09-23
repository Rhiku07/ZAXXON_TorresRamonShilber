using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemySpawner;
     void Start()
    {
        Instantiate(enemyPrefab, enemySpawner.position, Quaternion.identity);
    }

    void Update()
    {
       
    }
    
   
        
  
}

