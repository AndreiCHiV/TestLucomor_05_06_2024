using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project_S
{
    public class ImageCharacterView : MonoBehaviour
    {
        [SerializeField] private Image _imageCharacter;

        public Sprite ImageCharacter
        {
            get=>_imageCharacter.sprite;
            set=>_imageCharacter.sprite = value;
        }

        public void DisActiveImage()
        {
            _imageCharacter.color = new Color(1f, 1f, 1f, 0.5f);
        }

        public void ActiveImage()
        {
            _imageCharacter.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
