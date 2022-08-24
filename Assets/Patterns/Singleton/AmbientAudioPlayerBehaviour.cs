using UnityEngine;

public class AmbientAudioPlayerBehaviour : MonoBehaviour
{
    #region --Properties-- (Auto)
    public static AmbientAudioPlayerBehaviour Instance { get; private set; }
    #endregion



    #region --Methods-- (Built In)
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    #endregion



    #region --Methods-- (Custom PUBLIC)
    public void FadeNewMusic(AudioClip clip)
    {
        // TODO
    }
    #endregion
}