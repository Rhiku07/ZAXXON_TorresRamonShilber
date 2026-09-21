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
    float limitX = 10;
    float limitY = 10;
    float MaxRotation = 60f;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        isAlive = true;
        Awake();
    }
    void Update()
    {
        if (isAlive == true)
        {
            CheckPosition();
        }


    }
    private void Awake()
    {
        //Creamos la instancia del asset de entradas IMPORTANTE: hay que activarlo en OnEnable()
        inputActions = new InputActions();

        //Cuando pulsamos el botón de fuego se ejecuta el método correspondiente
        
            inputActions.Player.MoveX.performed += ctx => moveX = ctx.ReadValue<float>();
            inputActions.Player.MoveX.canceled += _ => moveX = 0f;

            inputActions.Player.MoveY.performed += ctx => moveY = ctx.ReadValue<float>();
            inputActions.Player.MoveY.canceled += _ => moveY = 0f;

            inputActions.Player.Fire.started += _ => Fire();
        

        //Cuando activamos la entrada de mover en X le damos el variable a la valor, y al dejar de tocarla la ponemos en cero
       


    }
    void PlayerMove()
    {
        
            transform.Translate(Vector3.right*desplSpeed *moveX * Time.deltaTime, Space.World);
            transform.Translate(Vector3.up * desplSpeed * moveY * Time.deltaTime , Space.World);
        
    }

    void PlayerRotation()
    {
        transform.eulerAngles = Vector3.forward * -MaxRotation * moveX ;
    }
    void CheckPosition()
    {
        bool InlimitX = CheckPositionX(limitX);
        bool InlimitY = CheckPositionY(limitY);
       
        if (InlimitX == false && InlimitY == false)
        {
            PlayerMove();
            PlayerRotation();
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
    
    bool CheckPositionX(float limitX)
    {
        bool inLimit ;
        float posX = transform.position.x;
        if (posX > limitX && moveX > 0)
        {
            inLimit = true;
        }
        else if (posX < -limitX && moveX < 0)
        {
            inLimit = true;
        }
        else
        {
            {
                
                inLimit = false;
            }
        }
        return inLimit;
    }
    bool CheckPositionY(float limitY)
    {
        bool inLimitY = false;
        float posY = transform.position.y;
        if (posY > limitY && moveY > 0)
        {

            inLimitY = true;
        }
        else if (posY < -limitY && moveY < 0)
        {

            inLimitY = true;
        }
        else
        {
            {

                inLimitY = false;
            }
        }
        return inLimitY;
    } 
}
