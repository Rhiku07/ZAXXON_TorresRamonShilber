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
    Vector3 Newpos;
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
    private void Awake()
    {
        //Creamos la instancia del asset de entradas IMPORTANTE: hay que activarlo en OnEnable()
        inputActions = new InputActions();

        //Cuando pulsamos el botón de fuego se ejecuta el método correspondiente

        inputActions.Player.Fire.started += _ => Shoot();


        //Cuando activamos la entrada de mover en X le damos el variable a la valor, y al dejar de tocarla la ponemos en cero



    }
    void Shoot()
    {
        Vector3 CambioPos = new Vector3 ;
        Newpos = InitPos.position + CambioPos;
        Instantiate(MyPrefab, Newpos, Quaternion.identity);
        Invoke("SpawnPipe", 2f);
    }
}

