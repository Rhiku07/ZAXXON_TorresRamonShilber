using UnityEngine;

public class BlastManager : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float distance = 1f;
    [SerializeField] float verticalOffset = 1f;
    float blastSpeed = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 offset = new Vector3(0f, verticalOffset, distance);
        transform.position = playerTransform.position - offset;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * blastSpeed * Time.deltaTime);
        //Si la tubería se sale de la pantalla, la destruimos
        if (transform.position.z < 15f)
        {
            Destroy(gameObject);
        }
    }
}
