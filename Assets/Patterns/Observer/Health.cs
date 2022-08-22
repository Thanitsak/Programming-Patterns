using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region --Fields-- (Inspector)
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;
    #endregion



    #region --Fields-- (In Class)
    float currentHealth = 0;
    #endregion



    #region --Methods-- (Built In)
    private void Awake()
    {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }
    #endregion



    #region --Methods-- (Custom PUBLIC)
    public float GetHealth()
    {
        return currentHealth;
    }

    public void ResetHealth()
    {
        currentHealth = fullHealth;
    }
    #endregion



    #region --Methods-- (Custom PRIVATE)
    private IEnumerator HealthDrain()
    {
        while (currentHealth > 0)
        {
            currentHealth -= drainPerSecond;
            yield return new WaitForSeconds(1);
        }
    }
    #endregion
}