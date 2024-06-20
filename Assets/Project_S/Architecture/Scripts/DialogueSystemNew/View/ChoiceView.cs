using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class ChoiceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _choiseText;

        public string ChoiseText
        {
            get => _choiseText.text;
            set => _choiseText.text = value;
        }
    }
}
