using UnityEngine;

public class AmbientAudioPlayer
{
    #region --Fields-- (In Class)
    private static AmbientAudioPlayer _instance = null;
    #endregion



    #region --Constructors-- (PRIVATE)
    private AmbientAudioPlayer() // Default Constructor, no class outside can create an instance of this class 
    {
    }
    #endregion



    #region --Methods-- (Custom PUBLIC) ~static~
    public static AmbientAudioPlayer GetInstance()
    {
        if (_instance == null)
        {
            _instance = new AmbientAudioPlayer();
        }
        return _instance;
    }
    #endregion



    #region --Methods-- (Custom PUBLIC)
    public void FadeNewMusic(AudioClip clip)
    {
        // TODO
    }
    #endregion
}