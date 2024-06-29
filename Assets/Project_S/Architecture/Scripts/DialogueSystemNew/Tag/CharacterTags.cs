using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class CharacterTags : MonoBehaviour
    {
        [SerializeField] private SpeakerCharacterTag _speakerCharacterTag;


        private readonly Dictionary<string, IReadOnlyTag> _map = new Dictionary<string, IReadOnlyTag>();

        public void Initialize()
        {
            _map.Add(_speakerCharacterTag.NameTag, _speakerCharacterTag);
        }

        public IReadOnlyTag GetValue(string key)
        {
            return _map.GetValueOrDefault(key);
        }
    }
}
