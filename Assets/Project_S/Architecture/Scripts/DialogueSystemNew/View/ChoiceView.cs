using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project_S
{
    public class ChoiceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _choiseText;
        [SerializeField] private Image _imageChanged;

        private int _index;

        public int Index
        {
            get => _index;
            set => _index = value;
        }

        public string ChoiseText
        {
            get => _choiseText.text;
            set => _choiseText.text = value;
        }

        public void SetActiveChoise()
        {
            _imageChanged.color = new Color(1f, 1f, 1f, 1f);
        }
        public void SetNotActiveChoise()
        {
            _imageChanged.color = new Color(1f, 0f, 0f, 0.5f);
        }
    }
}
