using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class EnemySpawner : MonoBehaviour
{
    // Prefab que voy a spawnear con array
    [SerializeField] GameObject[] enemies;

    // intervalos
    [SerializeField] float interval = 0.1f;

    // limites
     float limitX = 20f;
     float limitUp = 20f;
     float limitDown = -10f;

    // distancia entre enemigos
    [SerializeField] float firstEnemyDistance;
    [SerializeField] float distanceBetweenEnemies;
    
    // oleadas
    float waves = 5;
    
    // jugador
    [SerializeField] PlayerManager playerManager;
    bool isSpawning;
    void Start()
    {
        interval = 0.1f;


    }
   
    public void StartSpawn()
    {
        if (isSpawning==false)
        {
           
            StartCoroutine("SpawnEnemy");
            EnemigosIntermedios();
            firstEnemyDistance = 100f;
            distanceBetweenEnemies = 5f;
            isSpawning = true;
        }
      
       
    }
    void SacarNave(float distanceZ)
    {
        float randomX = Random.Range(-limitX, limitX);
        float randomY = Random.Range(limitDown, limitUp);
        // Posición aleatoria, pero en el spawner
        Vector3 despl = new Vector3(randomX, randomY, distanceZ);
        Vector3 instPost = transform.position + despl;
        int r = Random.Range(0, enemies.Length);
        Instantiate(enemies[r], instPost, Quaternion.identity);

    }
    void EnemigosIntermedios()
    {
        float distanceToFill = transform.position.z - firstEnemyDistance;
        float n = distanceToFill / distanceBetweenEnemies;
        int ciclos = Mathf.FloorToInt(n);
        for (int i = 0; i < ciclos; i++)
        {
            SacarNave(-distanceToFill);
            distanceToFill -= distanceBetweenEnemies;
        }

    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int n = 0; n < waves; n++)
            {
                SacarNave(0);

            }
            interval = distanceBetweenEnemies / playerManager.worldSpeed;
            yield return new WaitForSeconds(interval);

        }
    }

}

