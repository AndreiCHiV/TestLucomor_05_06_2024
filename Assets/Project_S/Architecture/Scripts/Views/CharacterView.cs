using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class CharacterView : MonoBehaviour
    {
        public event Action<Vector3> PositionCharacterChanged;

        [SerializeField] private TMP_Text _textName;
        [SerializeField] private TMP_Text _textMaxHealth;
        [SerializeField] private TMP_Text _textCurrentHealth;

        [SerializeField] private string _name;
        [SerializeField] private Animator _animator;

        public float moveSpeed;

        private bool _isMoving;


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

        public Vector3 CharacterPositionView
        {
            get => transform.position;
            set
            {
                if (transform.position != value)
                {
                    transform.position = value;
                }
            }
        }

        public bool IsMoving
        {
            get => _isMoving;
            set => _isMoving = value;
        }

        public Animator GetAnimation()
        {
            return _animator;
        }

        public void Movement(Vector2 input)
        {

            if (input.x != 0)
                input.y = 0;

            if (input != Vector2.zero)
            {

                _animator.SetFloat("moveX", input.x);
                _animator.SetFloat("moveY", input.y);

                Vector3 targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                StartCoroutine(Move(targetPos));
                PositionCharacterChanged?.Invoke(transform.position);
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
