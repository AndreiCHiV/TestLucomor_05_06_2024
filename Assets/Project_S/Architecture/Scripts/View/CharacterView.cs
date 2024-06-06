using UnityEngine;

namespace Assets.Project_S
{
    public class CharacterView : MonoBehaviour
    {
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
            int HP = _character.CurrentHelth;

            Debug.Log($"Name character: {name}, maxHP: {maxHP}, HP: {HP}!");
        }


    }
}
