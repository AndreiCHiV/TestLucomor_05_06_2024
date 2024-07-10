using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project_S
{
    public class QuestView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameQuest;
        [SerializeField] private TMP_Text _ownerQuest;
        [SerializeField] private Image _imageBackground;

        private int _questId;
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
        

        public void SetActiveSlotQuest()
        {
            _imageBackground.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
        public void SetNotActiveSlotQuest()
        {
            _imageBackground.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        }
    }
}