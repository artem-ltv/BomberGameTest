using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bomb : MonoBehaviour
{
    public float DelayExplosion;

    [SerializeField] private float _moveSpeedToCenterGround;

    private Rigidbody _rigidbody;
    private Collider _bombCollider;
    private bool isDrop;
    private Vector3 groundPosition;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.mass = 1;
        _bombCollider = GetComponent<Collider>();
        _rigidbody.freezeRotation = true;
        StartCoroutine(Explode(DelayExplosion));
        
    }

    private void Update()
    {
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
            Physics.IgnoreCollision(_bombCollider, enemyCollider);
        }

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Collider playerCollider = player.GetComponent<Collider>();
            Physics.IgnoreCollision(_bombCollider, playerCollider);
        }
    }
    
    private IEnumerator Explode(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
