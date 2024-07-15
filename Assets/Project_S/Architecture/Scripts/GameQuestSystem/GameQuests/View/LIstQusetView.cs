
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project_S
{
    public class ListQusetView : MonoBehaviour
    {
        [SerializeField] private Image _imageBackground;

        public void SetActiveSlotQuest()
        {
            _imageBackground.color = new Color(0f, 0.7f, 1f, 1f);
        }
        public void SetNotActiveSlotQuest()
        {
            _imageBackground.color = new Color(0f, 0.7f, 1f, 0.3f);
        }
    }
}