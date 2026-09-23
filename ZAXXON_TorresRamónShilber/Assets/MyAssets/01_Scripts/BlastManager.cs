using UnityEngine;

public class BlastManager : MonoBehaviour
{
    [SerializeField] float blastSpeed = 40f;
    [SerializeField] float lifeTime = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * blastSpeed * Time.deltaTime, Space.World);
         Object.Destroy(gameObject,lifeTime);
    }
}
