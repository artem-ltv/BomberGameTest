using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Player _player;

    private Rigidbody _rigidbody;
    private bool isMoving;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        isMoving = true;
    }

    private void OnEnable() =>
        _player.Dying += BanMovement;

    private void OnDisable() =>
        _player.Dying -= BanMovement;


    private void Update()
    {
        if (isMoving)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(-horizontal, 0f, -vertical);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * _rotationSpeed);
            _rigidbody.velocity = Vector3.ClampMagnitude(direction, 1) * _moveSpeed;

            _playerAnimator.SetFloat("MoveSpeed", Mathf.Abs(vertical + horizontal));
        }
    }
    private void BanMovement() =>
        isMoving = false;

}
