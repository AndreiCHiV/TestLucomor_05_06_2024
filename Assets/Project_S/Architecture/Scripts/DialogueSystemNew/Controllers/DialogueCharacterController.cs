using UnityEngine;

namespace Assets.Project_S
{
    public class DialogueCharacterController
    {
        private ScreenDialogueCharacterView _view;
        public DialogueCharacterController(IReadOnlyDialogueCharacter data, ScreenDialogueCharacterView view, CharacterView characterViewRight, CharacterView characterViewLeft)
        {
            _view = view;

            view.Init();
            view.IsMovingCharacter = characterViewLeft;
            Debug.Log(characterViewRight.ImageCharacter);
            Debug.Log(characterViewLeft.ImageCharacter);
            view.SetImageCharacter(characterViewRight.ImageCharacter, characterViewLeft.ImageCharacter);
            view.SetName(characterViewRight.Name, characterViewLeft.Name);

            IReadOnlyDialogue dialogue = data.GetDialogueStory(1);//получение ID диалога из Wise, должен плучать из списка заданий

            view.EnterDialogueMode(dialogue.GetDialogue());

        }
    }
}
