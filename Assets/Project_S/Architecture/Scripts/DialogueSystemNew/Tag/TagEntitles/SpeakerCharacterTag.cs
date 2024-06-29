using UnityEngine;

namespace Assets.Project_S
{
    public class SpeakerCharacterTag : MonoBehaviour, IReadOnlyTag
    {
        [SerializeField] private DialogueCharacterView _dialogueCharcterView;

        private const string NAMETAG = "speacker";
        public string NameTag
        {
            get => NAMETAG;
        }

        public void Calling(string value)
        {
            _dialogueCharcterView.SetNameCharacter(value);
        }

    }
}
