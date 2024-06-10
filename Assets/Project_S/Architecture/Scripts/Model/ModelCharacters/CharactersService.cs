using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class CharactersService
    {

        private readonly Dictionary<string, Character> _charactersMap = new Dictionary<string, Character>();
        //private Vector3 _input;

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

        //public IEnumerator MovementCharacter(string characterName)
        //{
        //    _input.x = Input.GetAxisRaw("Horizontal");
        //    _input.y = Input.GetAxisRaw("Vertical");
        //    Character character = _charactersMap[characterName];
            
        //    return character.Movement(_input);
        //}


        public IReadOnlyCharacter GetCharacter(string characterName)
        {
            return _charactersMap[characterName];
        }

        //public bool GetIsMoving(string characterName)
        //{
        //    Character character = _charactersMap[characterName];
        //    return character.IsMoving;
        //}
    }
}
