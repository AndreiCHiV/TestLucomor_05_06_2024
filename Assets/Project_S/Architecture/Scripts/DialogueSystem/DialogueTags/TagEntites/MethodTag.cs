using UnityEngine;

namespace Assets.Project_S
{
    public class MethodTag : MonoBehaviour, ITag
    {
        public void Calling(string value)
        {
            var dialogueMethods = GetComponent<DialogueMothod>();
            var method = dialogueMethods.GetType().GetMethod(value);

            method.Invoke(dialogueMethods, null);
        }
    }
}
