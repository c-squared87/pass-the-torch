using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;

    [SerializeField] float xoffset, yoffset, moveSpeed;

    void LateUpdate()
    {
        if (target == null) { target = FindObjectOfType<Player>().transform; }

        Vector3 _position = new Vector3(target.position.x + xoffset, target.position.y + yoffset, -10);

        transform.position = Vector3.MoveTowards(transform.position, _position, Time.deltaTime * moveSpeed);
    }
}
