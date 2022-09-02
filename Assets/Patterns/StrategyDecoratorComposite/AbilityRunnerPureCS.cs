using UnityEngine;

namespace PureCSSide
{
    public class AbilityRunnerPureCS : MonoBehaviour
    {
        #region --Fields-- (In Class)
        //private IAbilityStrategy _currentAbility = new RageAbility();
        //private IAbilityStrategy _currentAbility = new DelayedDecorator(new RageAbility());
        private IAbilityStrategy _currentAbility =
            new SequenceComposite(
                new IAbilityStrategy[] {
                    new FireballAbility(),
                    new RageAbility(),
                    new DelayedDecorator(new RageAbility())
                });
        #endregion



        #region --Methods-- (Custom PUBLIC)
        public void UseAbility()
        {
            _currentAbility.Use(gameObject);
        }
        #endregion
    }

    public interface IAbilityStrategy
    {
        public void Use(GameObject currentGameObject);
    }

    public class FireballAbility : IAbilityStrategy
    {
        #region --Methods-- (Interface)
        public void Use(GameObject currentGameObject)
        {
            Debug.Log("Launch Fireball");
        }
        #endregion
    }

    public class RageAbility : IAbilityStrategy
    {
        #region --Methods-- (Interface)
        public void Use(GameObject currentGameObject)
        {
            Debug.Log("I'm always angry");
        }
        #endregion
    }

    public class HealAbility : IAbilityStrategy
    {
        #region --Methods-- (Interface)
        public void Use(GameObject currentGameObject)
        {
            Debug.Log("Here eat this!");
        }
        #endregion
    }

    public class DelayedDecorator : IAbilityStrategy
    {
        #region --Fields-- (In Class)
        private IAbilityStrategy _wrappedAbility;
        #endregion



        #region --Constructors-- (PUBLIC)
        // NEED TO HAVE CONSTRUCTOR CUZ BEIGN USE AS Pure C#. In Unity simply create this class as ScriptableObject.
        public DelayedDecorator(IAbilityStrategy wrappedAbility)
        {
            _wrappedAbility = wrappedAbility;
        }
        #endregion



        #region --Methods-- (Interface)
        public void Use(GameObject currentGameObject)
        {
            // TODO ...some delaying functionality...

            _wrappedAbility.Use(currentGameObject);
        }
        #endregion
    }

    public class SequenceComposite : IAbilityStrategy
    {
        #region --Fields-- (In Class)
        private IAbilityStrategy[] _sequenceAbilities;
        #endregion



        #region --Constructors-- (PUBLIC)
        // NEED TO HAVE CONSTRUCTOR CUZ BEIGN USE AS Pure C#. In Unity simply create this class as ScriptableObject.
        public SequenceComposite(IAbilityStrategy[] sequenceAbilities)
        {
            _sequenceAbilities = sequenceAbilities;
        }
        #endregion



        #region --Methods-- (Interface)
        public void Use(GameObject currentGameObject)
        {
            foreach (IAbilityStrategy ability in _sequenceAbilities) // IF we calling them randomly that will be "RandomComposite.cs"
            {
                ability.Use(currentGameObject);
            }
        }
        #endregion
    }
}