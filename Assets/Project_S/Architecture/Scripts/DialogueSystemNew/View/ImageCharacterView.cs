using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project_S
{
    public class ImageCharacterView:MonoBehaviour
    {
        [SerializeField] private Image _imageCharacter;

        public Image ImageCharacter
        {
            get => _imageCharacter;
            set => _imageCharacter = value;
        }
    }
}
