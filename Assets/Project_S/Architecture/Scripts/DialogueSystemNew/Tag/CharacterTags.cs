using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class CharacterTags : MonoBehaviour
    {
        [SerializeField] private SpeakerCharacterTag _speakerCharacterTag;
        [SerializeField] private ChangeDialogueTag _changeDialogueTag;
        [SerializeField] private AddQuestTag _addQuestTag;
        [SerializeField] private AddItemTag _addItemTag;


        private readonly Dictionary<string, IReadOnlyTag> _map = new Dictionary<string, IReadOnlyTag>();

        public void Initialize()
        {
            _map.Add(_speakerCharacterTag.NameTag, _speakerCharacterTag);
            _map.Add(_changeDialogueTag.NameTag, _changeDialogueTag);
            _map.Add(_addQuestTag.NameTag, _addQuestTag);
            _map.Add(_addItemTag.NameTag, _addItemTag);
        }

        public IReadOnlyTag GetValue(string key)
        {
            return _map.GetValueOrDefault(key);
        }
    }
}
