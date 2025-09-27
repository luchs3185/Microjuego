using UnityEngine;

public class CameraWrapp : MonoBehaviour
{
    void Update()
    {
        Vector3 pos = transform.position;

        float camHeight = Camera.main.orthographicSize * 2f;
        float camWidth = camHeight * Camera.main.aspect;

        float leftBound = Camera.main.transform.position.x - camWidth / 2f;
        float rightBound = Camera.main.transform.position.x + camWidth / 2f;
        float bottomBound = Camera.main.transform.position.y - camHeight / 2f;
        float topBound = Camera.main.transform.position.y + camHeight / 2f;

        // si salgo por la derecha → entro por la izquierda
        if (pos.x > rightBound)
            pos.x = leftBound;
        else if (pos.x < leftBound)
            pos.x = rightBound;

        // si salgo por arriba → entro por abajo
        if (pos.y > topBound)
            pos.y = bottomBound;
        else if (pos.y < bottomBound)
            pos.y = topBound;

        transform.position = pos;
    }
}
