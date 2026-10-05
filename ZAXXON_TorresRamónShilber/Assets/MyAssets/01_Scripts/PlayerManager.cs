using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
   
    [SerializeField]float baseWorldSpeed = 10f;
    [SerializeField] public float worldSpeed;
    [SerializeField] float desplSpeed;
    [SerializeField] float limitX = 20f;
    [SerializeField] float limitY = 20f;
    [SerializeField] BlastSpawner blastSpawner;
    [SerializeField] float maxWorldSpeed = 50f;
    [SerializeField] float maxDesplSpeed = 30f;
   


    bool isAlive;
    float aceleracion = 40f;
    float desplAceleracion = 40f;
    float baseDesplSpeed = 10f;
    bool isFaster;
    float moveX;
    float moveY;
   
    InputActions inputActions;

      float rotation;
    float maxRotationZ = 35f;
    float maxRotationX = 15f;

    //ROTACIÓN SUAVIZADA
    [SerializeField] float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    Vector3 currentRot;


    void Awake()
    {
        inputActions = new InputActions();

        inputActions.Player.MoveX.performed += ctx => moveX = ctx.ReadValue<float>();
        inputActions.Player.MoveX.canceled += _ => moveX = 0f;

        inputActions.Player.MoveY.performed += ctx => moveY = ctx.ReadValue<float>();
        inputActions.Player.MoveY.canceled += _ => moveY = 0f;

        inputActions.Player.Fire.started += _ => blastSpawner.Fire();

        inputActions.Player.Faster.started += _ => isFaster = true; 
        inputActions.Player.Faster.canceled += _ => isFaster = false;

        
    }

    void Start()
    {
        isAlive = true;
        isFaster = false;
        worldSpeed = baseWorldSpeed;
    }

    void Update()
    {
        if (isAlive) {
            CheckPosition();
        }
           
    }

    void CheckPosition()
    {
        bool bloqueadoX = FueraDeLimiteX();
        bool bloqueadoY = FueraDeLimiteY();
        PlayerRotation();
        Accelerate();
    }

    void PlayerMove(bool bloqueadoX, bool bloqueadoY)
    {
        float mx = bloqueadoX ? 0f : moveX;
        float my = bloqueadoY ? 0f : moveY;
        transform.Translate(Vector3.right * desplSpeed*  mx * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * desplSpeed * my * Time.deltaTime, Space.World);
    }

    void PlayerRotation()
    {
        Vector3 vectorRotZ = Vector3.forward * -maxRotationZ * moveX;
        Vector3 vectorRotX = Vector3.right * -maxRotationX * moveY;
        Vector3 vectorRot = vectorRotX + vectorRotZ;
        currentRot = Vector3.SmoothDamp(currentRot, vectorRot, ref velocity, smoothTime);
        transform.eulerAngles = currentRot;
    }

   

    bool FueraDeLimiteX()
    {
        float posX = transform.position.x;
        if (posX > limitX && moveX > 0) return true;
        if (posX < -limitX && moveX < 0) return true;
        return false;
    }

    bool FueraDeLimiteY()
    {
        float posY = transform.position.y;
        if (posY > limitY && moveY > 0) return true;
        if (posY < -limitY && moveY < 0) return true;
        return false;
    }

    void Accelerate()
    {
        if (isFaster)
        {
            worldSpeed += aceleracion * Time.deltaTime;
            desplSpeed += desplAceleracion  * Time.deltaTime;

            if (worldSpeed >= maxWorldSpeed && desplSpeed >= desplAceleracion)
            {
                worldSpeed = maxWorldSpeed;
                desplSpeed = maxDesplSpeed;

            }
        }
        else
        {
            worldSpeed = baseWorldSpeed;
            desplSpeed = baseDesplSpeed;
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