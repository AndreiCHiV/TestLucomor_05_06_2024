using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class CooldownTag : MonoBehaviour, ITag
    {
        public void Calling(string value)
        {
            float number = (float)Convert.ToDouble(value.Replace(".", ","));

            DialogueWindow dialogueWindow = GetComponent<DialogueWindow>();

            try
            {
                dialogueWindow.SetCoolDown(number);
            }
            catch (ArgumentException ex)
            {
                Debug.LogError(ex.Message);
            }

        }
    }
}
