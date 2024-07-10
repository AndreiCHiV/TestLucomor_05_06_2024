using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class CharacterTags : MonoBehaviour
    {
        [SerializeField] private SpeakerCharacterTag _speakerCharacterTag;
        [SerializeField] private ChangeDialogueTag _changeDialogueTag;
        [SerializeField] private AddQuestTag _addQuestTag;
        [SerializeField] private ContinueQuestTag _continueQuestTag;
        [SerializeField] private CompletedQuestTag _completedQuestTag;
        [SerializeField] private AddItemTag _addItemTag;
        [SerializeField] private RemoveItemTag _removeItemTag;

        private readonly Dictionary<string, IReadOnlyTag> _map = new Dictionary<string, IReadOnlyTag>();

        public void Initialize()
        {
            _map.Add(_speakerCharacterTag.NameTag, _speakerCharacterTag);
            _map.Add(_changeDialogueTag.NameTag, _changeDialogueTag);
            _map.Add(_addQuestTag.NameTag, _addQuestTag);
            _map.Add(_addItemTag.NameTag, _addItemTag);
            _map.Add(_continueQuestTag.NameTag, _continueQuestTag);
            _map.Add(_completedQuestTag.NameTag, _completedQuestTag);
            _map.Add(_removeItemTag.NameTag, _removeItemTag);
        }

        public IReadOnlyTag GetValue(string key)
        {
            return _map.GetValueOrDefault(key);
        }
    }
}
