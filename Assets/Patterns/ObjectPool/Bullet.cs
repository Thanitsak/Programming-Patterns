using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    #region --Fields-- (Inspector)
    [SerializeField] private Vector3 _speed;
    #endregion



    #region --Fields-- (In Class)
    private IObjectPool<Bullet> _bulletPool;
    #endregion



    #region --Methods-- (Built In)
    private void Update()
    {
        transform.position += _speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        _bulletPool.Release(this);
    }
    #endregion



    #region --Methods-- (Custom PUBLIC)
    public void Setup(IObjectPool<Bullet> objectPool)
    {
        _bulletPool = objectPool;
    }
    #endregion
}