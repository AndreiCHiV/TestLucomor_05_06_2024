using System;

namespace Assets.Project_S
{
    public class CharacterController
    {
        private CharacterView _view;

        public CharacterController(IReadOnlyCharacter character, CharacterView view)
        {
            _view = view;

            character.MaxHealthChanged += ChangedMaxHealth;
            character.CurrentHealthChanged += ChangedCurrentHealth;

            view.CharacterName = character.Name;
            view.MaxHealth = character.MaxHealth;
            view.CurrentHealth = character.CurrentHealth;

        }

        private void ChangedCurrentHealth(int value)
        {
            _view.CurrentHealth = value;
        }

        private void ChangedMaxHealth(int value)
        {
            _view.MaxHealth = value;
        }
    }
}
