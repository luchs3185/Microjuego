using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifetinme = 3f; //tiempo de vida maximo de la bala para ahorrar recursos
                                    
    public Vector3 targetVector; //la direccion de la nave dirige la direccion de la bala

    void Start()
    {
        Destroy(gameObject, maxLifetinme); //destruye la bala despues de 3 segundos
    }

    void Update()
    { 
        transform.Translate(targetVector * speed * Time.deltaTime); //mueve la bala en la direccion de la nave 
    }   
}
