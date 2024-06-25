using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class Tags : MonoBehaviour
    {
        private readonly Dictionary<string, ITag> _map = new Dictionary<string, ITag>();

        private void Start()
        {
            _map.Add("speaker", GetComponent<SpeackerTag>());
            _map.Add("method", GetComponent<MethodTag>());
            _map.Add("cooldown", GetComponent<CooldownTag>());
        }

        public ITag GetValue(string key)
        {
            return _map.GetValueOrDefault(key);
        }

    }
}
