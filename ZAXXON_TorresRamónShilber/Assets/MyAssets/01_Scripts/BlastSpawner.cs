using UnityEngine;

public class BlastSpawner : MonoBehaviour
{
   
    
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
   

    void Start()
    {
       
    }

    void Update()
    {
      
    }
    public void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}

