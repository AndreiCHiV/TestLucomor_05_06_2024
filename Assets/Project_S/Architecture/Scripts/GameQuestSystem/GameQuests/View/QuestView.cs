using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class QuestView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameQuest;
        [SerializeField] private TMP_Text _ownerQuest;

        private int _questId;
        private byte _currnetQuest;
        private string _viewMessage;

        public string NameQuest
        {
            get => _nameQuest.text;
            set => _nameQuest.text = value;
        }

        public string OwnerQuest
        {
            get => _ownerQuest.text;
            set => _ownerQuest.text = value;
        }

        public string ViewMessage
        {
            get => _viewMessage;
            set => _viewMessage = value;
        }
        public int QuestId
        {
            get => _questId;
            set => _questId = value;
        }

        public byte CurrentQuest
        {
            get => _currnetQuest;
            set => _currnetQuest = value;
        }
    }
}