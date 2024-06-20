using System;

namespace Assets.Project_S
{
    public interface IReadOnlyDialoguesCharacter
    {
        event Action<int> AddDialogueChanged;
        event Action<int> RemoveDialogueChanged;

        string GetDialogueStory(int dataDialogueID);
    }
}
