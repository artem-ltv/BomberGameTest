using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private float _delayExplosion;
    [SerializeField] private float _moveSpeedToCenterGround;

    private Rigidbody _rigidbody;
    private bool isDrop;
    private Vector3 groundPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        StartCoroutine(Explode(_delayExplosion));
    }

    private void Update()
    {
        if (isDrop)      
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position , new Vector3(groundPosition.x, gameObject.transform.position.y, groundPosition.z), _moveSpeedToCenterGround * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            groundPosition = collision.gameObject.GetComponent<Renderer>().bounds.center;
            isDrop = true;
        }
    }
    
    private IEnumerator Explode(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
