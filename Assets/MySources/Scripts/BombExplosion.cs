using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] private float _explosionLength;
    [SerializeField] private float _secondExplosion;
    [SerializeField] private LayerMask _layerMaskWall;
    [SerializeField] private GameObject _explosionObject;

    private List<Vector3> CellsForExplodeForward;
    private List<Vector3> CellsForExplodeBackward;
    private List<Vector3> CellsForExplodeRight;
    private List<Vector3> CellsForExplodeLeft;

    private void Start() =>
        _explosionLength *= 4f;
    
    public void LaunchExplosion(Bomb bomb)
    {
        StartCoroutine(DetermineAndActiveExplosion(bomb, CellsForExplodeForward, bomb.transform.forward));
        StartCoroutine(DetermineAndActiveExplosion(bomb, CellsForExplodeBackward, bomb.transform.forward * -1));
        StartCoroutine(DetermineAndActiveExplosion(bomb, CellsForExplodeRight, bomb.transform.right));
        StartCoroutine(DetermineAndActiveExplosion(bomb, CellsForExplodeLeft, bomb.transform.right * -1));
    }

    private IEnumerator DetermineAndActiveExplosion(Bomb bomb ,List<Vector3> lineExplosion, Vector3 direction)
    {
        yield return new WaitForSeconds(bomb.DelayExplosion);

        lineExplosion = new List<Vector3>();

        for (int i = 2; i <= _explosionLength + 2; i += 4)
        {
            RaycastHit hit;
            Ray ray = new Ray(bomb.transform.position, direction);

            if (Physics.Raycast(ray, out hit, (float)i, _layerMaskWall))
                break;
            
            else
            {
                if(direction == bomb.transform.forward)
                    AddExplosionPoint(bomb, lineExplosion, 0, (i-2));
                    
                if(direction == bomb.transform.forward * -1)
                    AddExplosionPoint(bomb, lineExplosion, 0, -(i-2));
                    
                if(direction == bomb.transform.right)
                    AddExplosionPoint(bomb, lineExplosion, (i-2), 0);
                   
                if (direction == bomb.transform.right * -1)
                    AddExplosionPoint(bomb, lineExplosion, -(i-2), 0);
                    
                foreach (var item in lineExplosion)
                {
                    GameObject objectExplosion = Instantiate(_explosionObject, item, Quaternion.identity);
                    StartCoroutine(DeleteObjectsExplosion(objectExplosion));
                }
            }
        }
    }

    private IEnumerator DeleteObjectsExplosion(GameObject objectExplode)
    {
        yield return new WaitForSeconds(_secondExplosion);
        Destroy(objectExplode);
    }

    private void AddExplosionPoint(Bomb bomb, List<Vector3> lineExplosion, float stepX, float stepZ) =>   
        lineExplosion.Add(new Vector3(bomb.transform.position.x + stepX, bomb.transform.position.y, bomb.transform.position.z + stepZ));

}
