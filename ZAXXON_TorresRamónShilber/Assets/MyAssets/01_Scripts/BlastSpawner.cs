using UnityEngine;
using UnityEngine.InputSystem;

public class BlastSpawner : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] float distance = 1f;
    [SerializeField] float verticalOffset = 0f;
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
}

