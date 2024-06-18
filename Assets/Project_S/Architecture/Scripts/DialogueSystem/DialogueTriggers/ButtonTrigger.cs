using Ink.Runtime;
using UnityEngine;

namespace Assets.Project_S
{
    public class ButtonTrigger : MonoBehaviour
    {
        [SerializeField] private  TextAsset _inkJSON;
        [SerializeField] private DialogueController _dialogueController;

        public void ChangeField(int value)
        {
            Story story = new Story(_inkJSON.text);

            story.variablesState["nameField"] = value;

            Debug.Log(story.variablesState["nameField"]);


            // или

            var currentStory = _dialogueController.CurrentStory;
            currentStory.variablesState["nameField"] = value;
            Debug.Log(currentStory.variablesState["nameField"]);

        }
    }
}
