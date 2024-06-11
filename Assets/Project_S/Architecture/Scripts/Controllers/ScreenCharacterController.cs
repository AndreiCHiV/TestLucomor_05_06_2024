using UnityEngine;

namespace Assets.Project_S
{
    public class ScreenCharacterController
    {
        private readonly CharactersService _charactersService;
        private readonly ScreenView _view;

        private CharacterController _currentCharacterController;

        public ScreenCharacterController(CharactersService charactersService, ScreenView view)
        {
            _charactersService = charactersService;
            _view = view;

            //foreach (CharacterView characterView in _view.CharacterViews)
            //{
            //    IReadOnlyCharacter character = _charactersService.GetCharacter(characterView.Name);
            //    _currentCharacterController = new CharacterController(character, characterView);
            //}

        }

        public void ActiveCharacter(string characterName)
        {
            IReadOnlyCharacter character = _charactersService.GetCharacter(characterName);
            CharacterView characterView = _view.GetCharacterView(characterName);

            _currentCharacterController = new CharacterController(character, characterView);
            Debug.Log($"Active caracter: {characterView.CharacterName}");
        }

    }
}
