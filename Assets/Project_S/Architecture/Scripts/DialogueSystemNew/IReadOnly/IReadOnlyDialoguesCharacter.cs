using System;

namespace Assets.Project_S
{
    public interface IReadOnlyDialogueCharacter
    {
        IReadOnlyDialogue GetDialogueStory(int dataDialogueID);
    }
}
