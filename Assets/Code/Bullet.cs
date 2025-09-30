using UnityEngine;
using TMPro;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 2f; //tiempo de vida de la bala
    private Rigidbody rb;
    private float timer;

    void Awake() //aqui se guarda el rigidbody
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch() //al disparar la bala, se le da velocidad a la derecha
    {
        rb.linearVelocity = transform.right * speed; 
        timer = lifeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Pool.Instance.ReturnBullet(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") //cuando colisiona con asteroide
        {
            Destroy(other.gameObject); //destruye el asteroide
            IncreaseScore();
            Pool.Instance.ReturnBullet(gameObject); //recicla la bala
        }
    }

    public void IncreaseScore()
    {
        // cuando un asteroide es destruido, llama a esta función para darnos puntos.
        Player.SCORE++;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        // llamamos a esta función cada vez que ganamos puntos para actualizar el marcador
        GameObject go = GameObject.FindGameObjectWithTag("Score");
        go.GetComponent<TextMeshProUGUI>().text = "Score: " + Player.SCORE;
    }


}
