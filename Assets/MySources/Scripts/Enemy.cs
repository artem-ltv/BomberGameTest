using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public void Die()
    {
        Debug.Log("___");
        Destroy(gameObject);
    }
}
