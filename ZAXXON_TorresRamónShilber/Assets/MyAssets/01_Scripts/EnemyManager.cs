using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    //La velocidad de movimiento, que la obtendré del jugador
    float speed;
   
    //El componente playerManager que tendrá el jugador
    [SerializeField] PlayerManager playerManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        playerManager = player.GetComponent<PlayerManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //Me muevo a la velocidad que diga el jugador
        speed = playerManager.worldSpeed;
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        
        if(transform.position.z < -15f)
        {
            Object.Destroy(gameObject);
        }

    }
}