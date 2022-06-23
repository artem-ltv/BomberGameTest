using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bomb : MonoBehaviour
{
    public float DelayExplosion;

    [SerializeField] private float _moveSpeedToCenterGround;
    [SerializeField] private ParticleSystem _fireEffect;
    [SerializeField] private Transform _fireWickPoint;
    [SerializeField] private AudioSource _wickAudio;

    private Rigidbody _rigidbody;
    private Collider _collider;
    private bool isDrop;
    private Vector3 groundPosition;
    private ParticleSystem _fireWickEffect;


    private void Start()
    {
        _wickAudio.Play();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.mass = 1;
        _collider = GetComponent<Collider>();
        _rigidbody.freezeRotation = true;
        _fireWickEffect = Instantiate(_fireEffect, _fireWickPoint.position, Quaternion.identity);
        StartCoroutine(Explode(DelayExplosion));
    }

    private void Update()
    {
        _fireWickEffect.transform.position = _fireWickPoint.position;
        if (isDrop)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position , new Vector3(groundPosition.x, gameObject.transform.position.y, groundPosition.z), _moveSpeedToCenterGround * Time.deltaTime);
            _rigidbody.mass = 1000;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            groundPosition = collision.gameObject.GetComponent<Renderer>().bounds.center;
            isDrop = true;
        }

        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Collider enemyCollider = enemy.GetComponent<Collider>();
            Physics.IgnoreCollision(_collider, enemyCollider);
        }

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Collider playerCollider = player.GetComponent<Collider>();
            Physics.IgnoreCollision(_collider, playerCollider);
        }
    }
    
    private IEnumerator Explode(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
