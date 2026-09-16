using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    bool isAlive;
    public float speed;
    [SerializeField] float desplSpeed;
    float moveX;
    float moveY;
    InputActions inputActions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        PlayerMove();
    }
    void Start()
    {
        isAlive = true;
        Awake();
    }
    private void Awake()
    {
        //Creamos la instancia del asset de entradas IMPORTANTE: hay que activarlo en OnEnable()
        inputActions = new InputActions();

        //Cuando pulsamos el botón de fuego se ejecuta el método correspondiente


        //Cuando activamos la entrada de mover en X le damos el variable a la valor, y al dejar de tocarla la ponemos en cero
        inputActions.Player.MoveX.performed += ctx => moveX = ctx.ReadValue<float>();
        inputActions.Player.MoveX.canceled += _ => moveX = 0f;

        inputActions.Player.MoveY.performed += ctx => moveY = ctx.ReadValue<float>();
        inputActions.Player.MoveY.canceled += _ => moveY = 0f;

        inputActions.Player.Fire.started += _ => Fire();


    }
    void PlayerMove()
    {
        if (isAlive == true)
        {
            transform.Translate(Vector3.right * desplSpeed * moveX * Time.deltaTime);
            transform.Translate(Vector3.up * desplSpeed * moveY * Time.deltaTime);
        }
    }


    void Fire()
    {
        print("POOM");
    }


    //IMPORTANTE: activar el Inpu
    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
