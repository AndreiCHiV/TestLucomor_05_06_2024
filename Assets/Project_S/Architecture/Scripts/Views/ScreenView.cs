using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class ScreenView : MonoBehaviour
    {
        [SerializeField] private List<CharacterView> _characterViews;

        public List<CharacterView> CharacterViews => _characterViews;

        public CharacterView GetCharacterView(string characterName)
        {
            foreach (CharacterView characterView in _characterViews)
            {
                if (characterName == characterView.Name)
                {
                    return characterView;
                }
            }
            throw new Exception("The Character was not found!");
        }

        public void MoveMentCharacter(string characterName, Vector2 characterInput)
        {
            CharacterView character = GetCharacterView(characterName);
            
            character.Movement(characterInput);
        }

    }
}
