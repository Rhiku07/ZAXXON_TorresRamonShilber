using UnityEngine;
using UnityEngine.InputSystem;

public class BlastSpawner : MonoBehaviour
{
    InputActions inputActions;
    [SerializeField] Transform playerTransform;
    [SerializeField] float distance = 1f;
    [SerializeField] float verticalOffset = 0f;
    [SerializeField] GameObject MyPrefab;
    [SerializeField] Transform InitPos;
    [SerializeField] float blastSpeed;
    Vector3 Newpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputActions.Player.Fire.started += _ => Shoot();
        Awake();
    }

  
    
    void LateUpdate()
    {
        Vector3 offset = new Vector3(0f, verticalOffset, distance);
        transform.position = playerTransform.position - offset;
    }
    private void Awake()
    {
        //Creamos la instancia del asset de entradas IMPORTANTE: hay que activarlo en OnEnable()
        inputActions = new InputActions();


    }


   
    void Shoot()
    {

        Vector3 spawnPos = playerTransform.position + playerTransform.forward * 1f;
        GameObject blast = Instantiate(MyPrefab, spawnPos, playerTransform.rotation);

        Rigidbody rb = blast.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = playerTransform.forward * 15f; // velocidad del proyectil
        }


    
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

}
    


