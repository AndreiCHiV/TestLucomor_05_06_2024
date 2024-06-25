using UnityEngine;

namespace Assets.Project_S
{
    public class SpeakerCharacterTag : MonoBehaviour, IReadOnlyTag
    {
        public void Calling(string value)
        {
            var dialogueWindow = GetComponent<DialogueWindow>();
            dialogueWindow.SetName(value);
        }
    }
}
