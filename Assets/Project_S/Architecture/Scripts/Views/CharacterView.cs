using System;
using System.Collections;
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

        public float moveSpeed;

        private bool _isMoving;
        private Vector2 _input;

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

        public Vector2 InputPosition
        {
            get => _input;
            set => _input = value;
        }

        public bool IsMoving
        {
            get => _isMoving;
            set => _isMoving = value;
        }

        public void Movement(Vector2 input)
        {
            if (input.x != 0)
                input.y = 0;

            if (input != Vector2.zero)
            {
                Vector3 targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                Debug.Log(targetPos.x);
                Debug.Log(targetPos.y);

                StartCoroutine(Move(targetPos));
            }
        }

        private IEnumerator Move(Vector3 targetPos)
        {
            _isMoving = true;
            while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                yield return null;
            }

            transform.position = targetPos;
            _isMoving = false;
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
