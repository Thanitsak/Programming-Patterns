using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    #region --Fields-- (Inspector)
    [SerializeField] int pointsPerLevel = 200;
    #endregion



    #region --Events-- (UnityEvent)
    [SerializeField] private UnityEvent _onLevelUp;
    #endregion



    #region --Events-- (Delegate)
    public delegate void SimpleDelegate();
    public event SimpleDelegate OnLevelUpActionSame; // Exactly Same as OnLevelUpAction
    #endregion



    #region --Events-- (Delegate as Action)
    public event Action OnLevelUpAction;
    #endregion



    #region --Fields-- (In Class)
    int experiencePoints = 0;
    #endregion



    #region --Methods-- (Built In)
    IEnumerator Start()
    {
        while (true)
        {
            GainExperience(50);
            yield return new WaitForSeconds(1f);
        }
    }
    #endregion



    #region --Methods-- (Custom PUBLIC)
    public void GainExperience(int points)
    {
        int oldLevel = GetLevel();
        experiencePoints += points;

        if (GetLevel() > oldLevel)
        {
            _onLevelUp.Invoke();

            OnLevelUpAction.Invoke();
        }
    }

    public int GetExperience()
    {
        return experiencePoints;
    }

    public int GetLevel()
    {
        return experiencePoints / pointsPerLevel;
    }
    #endregion
}