using System.Collections.Generic;

namespace Assets.Project_S
{
    public class CharacterTags
    {
        private readonly Dictionary<string, IReadOnlyTag> _map = new Dictionary<string, IReadOnlyTag>();

        public CharacterTags()
        {
            //_map.Add("speaker", new SpeakerCharacterTag());
        }

        public IReadOnlyTag GetValue(string key)
        {
            return _map.GetValueOrDefault(key);
        }
    }
}
