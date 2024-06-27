using System;

namespace Assets.Project_S
{
    public interface IReadOnlyDialogueCharacter
    {
        string Owner { get; }
        IReadOnlyDialogue GetDialogueStory(int dataDialogueID);
    }
}
