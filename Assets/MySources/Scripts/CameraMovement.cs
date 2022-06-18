using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _cameraSpeed;

    private Vector3 _targetPosition;

    private void Update()
    {
        _targetPosition = new Vector3(_player.transform.position.x - 12f, transform.position.y, _player.transform.position.z - 3);
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _cameraSpeed * Time.deltaTime);
    }
}
