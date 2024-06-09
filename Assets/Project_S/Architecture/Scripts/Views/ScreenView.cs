using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class ScreenView : MonoBehaviour
    {
        [SerializeField] private List<CharacterView> _characterView;


        public CharacterView GetCharacterView(string characterName)
        {
            foreach (CharacterView characterView in _characterView)
            {
                Debug.Log(characterView.Name);
                if (characterName == characterView.Name)
                {
                    return characterView;
                }
            }
            throw new Exception("The Character was not found!");
        }
    }
}
