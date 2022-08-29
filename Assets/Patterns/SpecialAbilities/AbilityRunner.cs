using UnityEngine;

public class AbilityRunner : MonoBehaviour
{
    enum Ability
    {
        Fireball,
        Rage,
        Heal
    }



    #region --Fields-- (Inspector)
    [SerializeField] private Ability _currentAbility = Ability.Fireball;
    #endregion



    #region --Methods-- (Custom PUBLIC)
    public void UseAbility()
    {
        switch (_currentAbility)
        {
            case Ability.Fireball:
                Debug.Log("Launch Fireball");
                break;
            case Ability.Rage:
                Debug.Log("I'm always angry");
                break;
            case Ability.Heal:
                Debug.Log("Here eat this!");
                break;
        }
    }
    #endregion
}