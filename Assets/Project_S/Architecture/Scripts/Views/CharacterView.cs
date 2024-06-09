using System;
using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class CharacterView : MonoBehaviour
    {

        [SerializeField] private TMP_Text _textName;
        [SerializeField] private TMP_Text _textMaxHealth;
        [SerializeField] private TMP_Text _textCurrentHealth;

        [SerializeField] private string _name;

        public string Name => _name;

        public string CharacterName
        {
            get => _textName.text;
            set => _textName.text = value;
        }

        public int MaxHealth
        {
            get => Convert.ToInt32(_textMaxHealth.text);
            set => _textMaxHealth.text = value.ToString();
        }

        public int CurrentHealth
        {
            get => Convert.ToInt32(_textCurrentHealth);
            set => _textCurrentHealth.text = value.ToString();
        }


        private IReadOnlyCharacter _character;

        public void Setup(IReadOnlyCharacter character)
        {
            _character = character;
            Print();
        }

        public void Print()
        {
            string name = _character.Name;
            int maxHP = _character.MaxHealth;
            int HP = _character.CurrentHealth;

            Debug.Log($"Name character: {name}, maxHP: {maxHP}, HP: {HP}!");
        }


    }
}
