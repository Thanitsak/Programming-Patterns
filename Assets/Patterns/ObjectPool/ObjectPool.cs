using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    #region --Fields-- (Inspector)
    [SerializeField] private GameObject[] _prefabsToPool;
    [SerializeField][Min(0)] private int _startPoolSize = 10;
    [SerializeField] private bool _canExpand = true;
    #endregion



    #region --Fields-- (In Class)
    private int _indexer = 0; // make all Prefabs (in case more than one to pool) get instantiate equally
    private readonly List<GameObject> _poolObjects = new List<GameObject>();
    #endregion



    #region --Properties-- (Auto)
    public static ObjectPool Instance { get; private set; }
    #endregion



    #region --Methods-- (Built In)
    private void Awake()
    {
        Instance = this;

        // Initialize Pool
        for (int i = 0; i < _startPoolSize; i++)
            Return(Instantiate(_prefabsToPool[GetIndex(ref _indexer)]));
    }
    #endregion



    #region --Methods-- (Custom PUBLIC)
    public GameObject Get(Transform parentTrans)
    {
        GameObject toGive;

        // Get object from pool randomly if avaiable, if not create one
        if (_poolObjects.Count > 0)
        {
            toGive = _poolObjects[Random.Range(0, _poolObjects.Count)];
            _poolObjects.Remove(toGive);
        }
        else
        {
            if (_canExpand)
                toGive = Instantiate(_prefabsToPool[GetIndex(ref _indexer)]);
            else
                return null;
        }

        toGive.transform.SetParent(parentTrans); // make it a child of parameter value (In case we want to do smth with it there)
        toGive.SetActive(true);

        return toGive;
    }

    public void Return(GameObject toReturn)
    {
        toReturn.transform.SetParent(transform); // make the instance a child of this (Just fill up the pool here)
        toReturn.SetActive(false);

        _poolObjects.Add(toReturn);
    }
    #endregion



    #region --Methods-- (Custom PRIVATE)
    private int GetIndex(ref int i) => i = (i < _prefabsToPool.Length - 1) ? ++i : 0;
    #endregion
}