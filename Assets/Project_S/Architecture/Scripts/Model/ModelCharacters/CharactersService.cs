using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class CharactersService
    {

        private readonly Dictionary<string, Character> _charactersMap = new Dictionary<string, Character>();

        public Character RegisterCharacters(CharacterData characterData)
        {
            Character character;

            if (characterData is PlayerCharacterData player)
            {
               character = new Player(player);
            }
            else if (characterData is NPCCharacterData npc)
            {
                character = new NPC(npc);
            }
            else
            {
                throw new Exception($"{characterData} is not belong to type Character!");
            }

            _charactersMap[character.Name] = character;

            return character;
        }

        public string TakeDamageCharacter(string characterName, int damage)
        {
            Character character = _charactersMap[characterName];
            return character.TakeDamage(damage);
        }
        public string TreatmentCharacter(string characterName)
        {
            Character character = _charactersMap[characterName];
            return character.Treatment();
        }

        public IReadOnlyCharacter GetCharacter(string characterName)
        {
            return _charactersMap[characterName];
        }
        public Vector3 GetPositinoCharacter(string characterName)
        {
            Character character = _charactersMap[characterName];
            return character.PositionCharacter;
        }
        public void SetPositionCharacter(string characterName, Vector3 positionCharacter)
        {
            Character character = _charactersMap[characterName];
            character.SetPositionCharacter(positionCharacter);
        }
    }
}
