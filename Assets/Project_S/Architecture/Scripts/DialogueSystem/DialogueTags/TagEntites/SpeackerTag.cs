using UnityEngine;

namespace Assets.Project_S
{
    public class SpeackerTag : MonoBehaviour, ITag
    {
        public void Calling(string value)
        {
            var dialogueWindow = GetComponent<DialogueWindow>();
            dialogueWindow.SetName(value);
        }
    }
}
