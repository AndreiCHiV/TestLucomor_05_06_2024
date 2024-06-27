using UnityEngine;

namespace Assets.Project_S
{
    public class ScreenDialogueCharacterController
    {
        private readonly DialogueCharacterService _service;
        private readonly ScreenDialogueCharacterView _view;

        private DialogueCharacterController _dialogueCharacterController;

        public ScreenDialogueCharacterController(DialogueCharacterService service, ScreenDialogueCharacterView view)
        {
            _service = service;
            _view = view;
        }

        public void EnterDialogueCharacter(CharacterView nameCharacter, CharacterView nameCharacterIsMoving)
        {
            IReadOnlyDialogueCharacter dialogue = _service.GetDialoguesCharacter(nameCharacter.Name);
            ScreenDialogueCharacterView dialogueView = _view;

            _dialogueCharacterController = new DialogueCharacterController(dialogue, dialogueView, nameCharacterIsMoving);
        }

    }
}
