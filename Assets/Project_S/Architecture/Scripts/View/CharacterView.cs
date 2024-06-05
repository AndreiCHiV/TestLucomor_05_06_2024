using UnityEngine;

namespace Assets.Project_S
{
    public class CharacterView : MonoBehaviour
    {
        public void Setup(IReadOnlyCharacter character)
        {
            string name = character.Name;
            int maxHP = character.MaxHealth;
            int HP = character.CurrentHelth;

            Debug.Log($"Name character: {name}, maxHP: {maxHP}, HP: {HP}!");
        }

    }
}
