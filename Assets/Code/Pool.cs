using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool Instance;

   
    public GameObject Bullet;
    public int initialPoolSize = 5;

    private Queue<GameObject> pool = new Queue<GameObject>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        Prewarm();
    }

    void Prewarm()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(Bullet, transform); // hijo del pool container
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetBullet()
    {
        GameObject obj;
        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
            obj.SetActive(true);
        }
        else
        {
            return null; // o podrías devolver un objeto reutilizado (estrategia alternativa)
        }

        // Lo sacamos de la jerarquía del pool para que no aparezca "dentro" del contenedor
        obj.transform.SetParent(null);
        return obj;
    }

    public void ReturnBullet(GameObject obj)
    {
        // Reset básico antes de guardar
        var rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
           rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // opcional: reset transform (si quieres)
        // obj.transform.position = transform.position;

        obj.SetActive(false);
        obj.transform.SetParent(transform); // lo volvemos a poner bajo el contenedor del pool
        pool.Enqueue(obj);
    }
}
