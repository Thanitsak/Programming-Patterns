using UnityEngine;

namespace UnitySide
{
    public class AbilityRunnerWithUnity : MonoBehaviour
    {
        #region --Fields-- (Inspector)
        [SerializeField] private AbilityStrategy _currentAbility;
        #endregion



        #region --Methods-- (Custom PUBLIC)
        public void UseAbility()
        {
            _currentAbility.Use(gameObject);
        }
        #endregion
    }

    // Interface can't be ScriptableObject, that's why we need an Abstract class to do so
    public interface IAbilityStrategy
    {
        public void Use(GameObject currentGameObject);
    }

    // Can also implement IAbility interface, and that will abstractly implement the interface method. BUT NO NEED TO DO, just abstract class alone here is fine.
    //public abstract class AbilityStrategy : ScriptableObject, IAbilityStrategy
    //{
    //    #region --Methods-- (Interface) ~Abstractly Implement~
    //    public abstract void Use(GameObject currentGameObject);
    //    #endregion
    //}
    public abstract class AbilityStrategy : ScriptableObject
    {
        #region --Methods-- (Custom PUBLIC)
        public abstract void Use(GameObject currentGameObject);
        #endregion
    }

    [CreateAssetMenu(fileName = "Ability Name", menuName = "Path/Create New Ability", order = 1)]
    public class FireballAbility : AbilityStrategy
    {
        #region --Methods-- (Override)
        public override void Use(GameObject currentGameObject)
        {
            Debug.Log("Launch Fireball");
        }
        #endregion
    }

    [CreateAssetMenu(fileName = "Ability Name", menuName = "Path/Create New Ability", order = 1)]
    public class RageAbility : AbilityStrategy
    {
        #region --Methods-- (Override)
        public override void Use(GameObject currentGameObject)
        {
            Debug.Log("I'm always angry");
        }
        #endregion
    }

    [CreateAssetMenu(fileName = "Ability Name", menuName = "Path/Create New Ability", order = 1)]
    public class HealAbility : AbilityStrategy
    {
        #region --Methods-- (Override)
        public override void Use(GameObject currentGameObject)
        {
            Debug.Log("Here eat this!");
        }
        #endregion
    }

    [CreateAssetMenu(fileName = "Ability Name", menuName = "Path/Create New Ability", order = 1)]
    public class DelayedDecorator : AbilityStrategy
    {
        #region --Fields-- (Inspector)
        [SerializeField] private AbilityStrategy _wrappedAbility;
        #endregion



        #region --Methods-- (Override)
        public override void Use(GameObject currentGameObject)
        {
            // TODO ...some delaying functionality...

            _wrappedAbility.Use(currentGameObject);
        }
        #endregion
    }

    [CreateAssetMenu(fileName = "Ability Name", menuName = "Path/Create New Ability", order = 1)]
    public class SequenceComposite : AbilityStrategy
    {
        #region --Fields-- (Inspector)
        [SerializeField] private AbilityStrategy[] _sequenceAbilities;
        #endregion



        #region --Methods-- (Override)
        public override void Use(GameObject currentGameObject)
        {
            foreach (AbilityStrategy ability in _sequenceAbilities) // IF we calling them randomly that will be "RandomComposite.cs"
            {
                ability.Use(currentGameObject);
            }
        }
        #endregion
    }
}