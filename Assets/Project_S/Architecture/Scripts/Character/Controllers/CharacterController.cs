using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class CharacterController : IDisposable
    {
        private CharacterView _view;
        IReadOnlyCharacter _character;

        public CharacterController(IReadOnlyCharacter character, CharacterView view)
        {
            _view = view;
            _character = character;

            character.MaxHealthChanged += ChangedMaxHealth;
            character.CurrentHealthChanged += ChangedCurrentHealth;
            character.PositionCharacterChanged += ChangedPositionCharacter;

            view.PositionCharacterChanged += ChangedPositionCharacterView;

            character.CurrentDialogueIDChanged += ChangedCurrentDialogueID;

            view.CharacterName = character.Name;
            view.MaxHealth = character.MaxHealth;
            view.CurrentHealth = character.CurrentHealth;
            view.DialogueId = character.CurrentDialogueID;
            view.CharacterID = character.ID;
            character.SetPositionCharacter(view.CharacterPositionView);
        }

        private void ChangedCurrentDialogueID(int value)
        {
            _view.DialogueId = value;
        }

        private void ChangedPositionCharacterView(Vector3 value)
        {
            _character.SetPositionCharacter(value);
        }

        private void ChangedPositionCharacter(Vector3 value)
        {
            _view.CharacterPositionView = value;
        }

        private void ChangedCurrentHealth(int value)
        {
            _view.CurrentHealth = value;
        }

        private void ChangedMaxHealth(int value)
        {
            _view.MaxHealth = value;
        }

        public void Dispose()
        {
            _character.MaxHealthChanged -= ChangedMaxHealth;
            _character.CurrentHealthChanged -= ChangedCurrentHealth;
            _character.PositionCharacterChanged -= ChangedPositionCharacter;

            _view.PositionCharacterChanged -= ChangedPositionCharacterView;
        }
    }
}
