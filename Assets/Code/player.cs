using UnityEngine;
using UnityEngine.InputSystem; // Necesario para el nuevo sistema

public class Player : MonoBehaviour
{
    [SerializeField] float thrustForce = 2f; // fuerza de empuje
    [SerializeField] float rotationSpeed = 120f; // velocidad de rotación

    public GameObject gun, bulletPrefab; // Prefab de la bala

    Vector2 thrustDirection; // dirección de empuje
    private Rigidbody _rigidbody;

    InputAction rotateAction;
    InputAction thrustAction;
    InputAction fireAction; // Acción para disparar

    void Start()
    {
        // rigidbody nos permite aplicar fuerzas en el jugador
        _rigidbody = GetComponent<Rigidbody>();

        // Obtenemos el PlayerInput del objeto
        var playerInput = GetComponent<PlayerInput>();

        // Buscamos las acciones que creamos en el asset
        rotateAction = playerInput.actions["Rotate"];
        thrustAction = playerInput.actions["Thrust"];
        fireAction = playerInput.actions["Fire"];

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

        if (fireAction.triggered) //se pregunta si se presiona el espacio
        {
            // Instanciamos la bala en la posición y rotación de la nave
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);

            Bullet balaScript = bullet.GetComponent<Bullet>(); //accede al componente bullet del nuevo Gobj que avano de instancia

            balaScript.targetVector = transform.right;

        }
    } 
    
}
