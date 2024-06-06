using UnityEngine;

namespace Assets.Project_S
{
    public class ScreenView : MonoBehaviour
    {
        [SerializeField] private CharacterView _characterView;

        public CharacterView CharacterView => _characterView;
    }
}
