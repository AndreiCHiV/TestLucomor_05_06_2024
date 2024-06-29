using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project_S
{
    public class ImageCharacterView : MonoBehaviour
    {
        [SerializeField] private Image _imageCharacter;

        public Sprite ImageCharacter
        {
            get => _imageCharacter.sprite;
            set => _imageCharacter.sprite = value;
        }
    }
}
