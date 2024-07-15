using System;

namespace Assets.Project_S
{
    [Serializable]
    public class QuestMessageData
    {
        public byte messageID;
        public int[] messageChangeDialogueID;
        public string message;
        public bool completedQuest;
        public bool failedQuest;
    }
}
