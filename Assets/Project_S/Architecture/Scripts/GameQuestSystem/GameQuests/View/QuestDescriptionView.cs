using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class QuestDescriptionView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _descriptionQuest;
        [SerializeField] private TMP_Text _owner;

        public string DescriptionQuest
        {
            get => _descriptionQuest.text;
            set => _descriptionQuest.text = value;
        }

        public string Owner
        {
            get => _owner.text;
            set => _owner.text = value;
        }
    }
}