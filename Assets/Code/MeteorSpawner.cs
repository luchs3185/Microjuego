using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnPerMinute = 30f;
    
    public float spawnRateIncrement = 1f; //ir aumentando la dificultad

    public float xlimit = 18f; //limite en el eje x

    public float maxLifeTime = 4f; //tiempo maximo de vida del asteroide
    

    private float spawnNext = 0;


    void Update()
    {
        if (Time.time > spawnNext) //generar un nuevo asteroide prefasb
        {
            spawnNext = Time.time + 60f / spawnPerMinute; //hhora actual mas el tiempo por minuto dividido la tasa de spawn
            spawnPerMinute += spawnRateIncrement; // Incrementa la tasa de spawn
            float random = Random.Range(-xlimit, xlimit); //generar un numero aleatorio entre -8 y 8
            Vector2 spawnPosition = new Vector2(random, 14f); //generar una posicion aleatoria en el eje x
            GameObject meteor = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity); //instanciar el asteroide en la posicion del spawner  
            Destroy(meteor, maxLifeTime); //destruir el asteroide despues de 10 segundos
        }
  
    }
}
