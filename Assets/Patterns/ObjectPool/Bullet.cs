using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region --Fields-- (Inspector)
    [SerializeField] private Vector3 _speed;
    #endregion



    #region --Methods-- (Built In)
    private void Update()
    {
        transform.position += _speed * Time.deltaTime;
    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    #endregion
}