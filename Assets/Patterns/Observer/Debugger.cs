using System.Collections;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    #region --Methods-- (Built In)
    IEnumerator Start()
    {
        Health health = GetComponent<Health>();
        Level level = GetComponent<Level>();
        while (true)
        {
            yield return new WaitForEndOfFrame(); // Wait for Level.cs to run first
            Debug.Log($"Exp: {level.GetExperience()}, Level: {level.GetLevel()}, Health: {health.GetHealth()}");
            yield return new WaitForSeconds(1f);
        }
    }
    #endregion
}