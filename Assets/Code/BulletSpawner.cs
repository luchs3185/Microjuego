using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public void SpawnBullet()
    {
        GameObject bulletObj = Pool.Instance.GetBullet();
        if (bulletObj == null) return;

        // colocamos la bala en la posición/rotación del spawner
        bulletObj.transform.position = transform.position;
        bulletObj.transform.rotation = transform.rotation;

        // llamamos al método Launch del componente Bullet
        var bulletComp = bulletObj.GetComponent<Bullet>();
        if (bulletComp != null) bulletComp.Launch();
        
    }
}
