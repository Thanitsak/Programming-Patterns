using UnityEngine;

public class Launcher : MonoBehaviour
{
    #region --Fields-- (Inspector)
    [SerializeField] private Bullet _bulletPrefab;
    #endregion



    #region --Methods-- (Built In)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_bulletPrefab);
        }
    }
    #endregion
}