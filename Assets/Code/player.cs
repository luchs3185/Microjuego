using UnityEngine;

public class Player : MonoBehaviour{
    float thrustForce = 5f; //fuerza de empuje
    float rotationSpeed = 120f; // velocidad de rotación
    Vector2 thrustDirection; // dirección de empuje
    Rigidbody _rigidbody; 
    void Start(){
    // rigidbody nos permite aplicar fuerzas en el jugador
    _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
    // obtenemos las pulsaciones de teclado
    float rotation = Input.GetAxis("Rotate") * rotationSpeed * Time.deltaTime;
    float thrust = Input.GetAxis("Thrust") * thrustForce;
    // la dirección de empuje por defecto es .right (el eje X positivo)
    thrustDirection = transform.right;
    // rotamos con el eje "Rotate" negativo para que la dirección sea correcta
    transform.Rotate(Vector3.forward, -rotation);
    // añadimos la fuerza capturada arriba a la nave del jugador
    _rigidbody.AddForce(thrust * thrustDirection);
    }
}
