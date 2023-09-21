using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private void LateUpdate()
    {
        transform.position = new Vector3(0, _player.transform.position.y + 3.5f, -10);
    }
}

