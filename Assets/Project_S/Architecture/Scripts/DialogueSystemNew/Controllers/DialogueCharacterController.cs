using UnityEngine;

namespace Assets.Project_S
{
    public class DialogueCharacterController
    {
        private ScreenDialogueCharacterView _view;
        public DialogueCharacterController(IReadOnlyDialogueCharacter data, ScreenDialogueCharacterView view, CharacterView characterView)
        {
            _view = view;

            view.Init();
            view.IsMovingCharacter = characterView;

            IReadOnlyDialogue dialogue = data.GetDialogueStory(1);//получение ID диалога из Wise, должен плучать из списка заданий

            view.EnterDialogueMode(dialogue.GetDialogue());

        }
    }
}
