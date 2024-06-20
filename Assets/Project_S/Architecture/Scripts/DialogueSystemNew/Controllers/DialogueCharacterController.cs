namespace Assets.Project_S
{
    public class DialogueCharacterController
    {
        private DialogueCharacterView _view;
        public DialogueCharacterController(IReadOnlyDialogueCharacter data, DialogueCharacterView view)
        {
            _view = view;
        }
    }
}
