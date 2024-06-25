using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    public class DialogueCharacterTag
    {
        private CharacterTags _tags = new CharacterTags();


        public void HandleTags(List<string> tags)
        {
            if (tags.Count == 0)
            {
                return;
            }

            foreach (string tagValue in tags)
            {
                string[] keyTag = tagValue.Split(":");

                if (keyTag.Length != 2)
                {
                    throw new ArgumentException("Неправельное оформление тега! Срочно исправить!");
                }

                string key = keyTag[0].Trim();
                string value = keyTag[1].Trim();

                _tags.GetValue(key).Calling(value);
            }

        }
    }
}
