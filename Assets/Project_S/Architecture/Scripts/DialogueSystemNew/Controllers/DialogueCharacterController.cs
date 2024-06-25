namespace Assets.Project_S
{
    public class DialogueCharacterController
    {
        private ScreenDialogueCharacterView _view;
        public DialogueCharacterController(IReadOnlyDialogueCharacter data, ScreenDialogueCharacterView view)
        {
            _view = view;

            view.Init();

            IReadOnlyDialogue dialogue = data.GetDialogueStory(1);

            view.EnterDialogueMode(dialogue.GetDialogue());
        }
    }
}
