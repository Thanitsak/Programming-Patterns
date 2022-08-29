using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour
{
    #region --Fields-- (Inspector)
    [SerializeField] private Bullet _bulletPrefab;
    #endregion



    #region --Properties-- (Auto)
    public IObjectPool<Bullet> BulletPool { get; private set; }
    #endregion



    #region --Methods-- (Built In)
    private void Awake()
    {
        BulletPool = new ObjectPool<Bullet>(CreatePoolItem, OnTakeFromPool, OnReturnedToPool, OnDestroyItem, collectionCheck:true, defaultCapacity:10, maxSize:3);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BulletPool.Get();
        }
    }
    #endregion



    #region --Methods-- (Subscriber) ~ObjectPool~
    private Bullet CreatePoolItem()
    {
        Bullet bullet = Instantiate(_bulletPrefab);
        bullet.Setup(BulletPool);

        return bullet;
    }

    private void OnTakeFromPool(Bullet bullet)
    {
        print("TAKE FROM POOL");
        bullet.gameObject.SetActive(true);
        bullet.transform.position = transform.position; // set back to Launcher position
    }

    private void OnReturnedToPool(Bullet bullet)
    {
        print("RETURNED");
        bullet.gameObject.SetActive(false);
    }

    // If the pool capacity is reached then any items returned will be destroyed, but will create more if needed. For Resources Saving Purpose, it needs memory for keeping items around.
    private void OnDestroyItem(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
    #endregion
}