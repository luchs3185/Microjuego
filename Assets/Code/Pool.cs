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
            GameObject obj = Instantiate(Bullet, transform); //hijo del pool container
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
            return null;
        }

        obj.transform.SetParent(null);
        return obj;
    }

    public void ReturnBullet(GameObject obj)
    {
        var rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
           rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        obj.SetActive(false);
        obj.transform.SetParent(transform);
        pool.Enqueue(obj);
    }
}
