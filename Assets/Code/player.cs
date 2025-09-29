using UnityEngine;
using UnityEngine.InputSystem; // Necesario para el nuevo sistema
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField] float thrustForce = 2f; // fuerza de empuje
    [SerializeField] float rotationSpeed = 120f; // velocidad de rotación


    Vector2 thrustDirection; // dirección de empuje
    private Rigidbody _rigidbody;
    public static int SCORE;
    InputAction rotateAction;
    InputAction thrustAction;

    void Start()
    {
        //para fuerzas en el jugador
        _rigidbody = GetComponent<Rigidbody>();

        //Obtenemos el PlayerInput del objeto
        var playerInput = GetComponent<PlayerInput>();
        SCORE = 0;
        //Buscamos las acciones que creamos en el asset
        rotateAction = playerInput.actions["Rotate"];
        thrustAction = playerInput.actions["Thrust"];


    }


    private void FixedUpdate()
    {
        // Leemos valores del Input System
        float rotation = rotateAction.ReadValue<float>() * rotationSpeed * Time.deltaTime;
        float thrust = thrustAction.ReadValue<float>() * thrustForce;

        // Dirección de empuje por defecto es el eje X positivo
        thrustDirection = transform.right;

        // Rotamos la nave
        transform.Rotate(Vector3.forward, -rotation);

        // Aplicamos la fuerza
        _rigidbody.AddForce(thrust * thrustDirection);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    } 
    
}
