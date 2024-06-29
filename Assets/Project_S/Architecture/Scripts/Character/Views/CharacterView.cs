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

        [SerializeField] private LayerMask _solidObjectsLayer;
        [SerializeField] private LayerMask _interactableLayer;
        [SerializeField] private LayerMask _interactablePlayerLayer;

        [SerializeField] private Sprite imegeCharacter;

        public float moveSpeed;

        public int _dialogueId;// временно public  потом должно инициализироваться в начале игры лист с диалогами 
        // и измениется через Model когда беруться или меняется задания

        private bool _isMoving;


        public string Name => _name;

        public int DialogueId
        {
            get => _dialogueId;
            set => _dialogueId = value;
        }
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

        public Sprite ImageCharacter
        {
            get => imegeCharacter;
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

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }

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

        public CharacterView Interact()
        {
            CharacterView character;

            Vector3 facingDir = new Vector3(_animator.GetFloat("moveX"), _animator.GetFloat("moveY"));
            Vector3 interactPos = transform.position + facingDir;

            Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

            Collider2D collider = Physics2D.OverlapCircle(interactPos, 0.2f, _interactableLayer | _interactablePlayerLayer);

            if (collider != null)
            {
                Debug.Log("there is an Object here!");

                character = collider.GetComponent<CharacterView>();
                return character;
            }

            return null;
        }

        private bool IsWalkable(Vector3 targetPos)
        {
            if (Physics2D.OverlapCircle(targetPos, 0.2f, _solidObjectsLayer | _interactableLayer | _interactablePlayerLayer) != null)
            {
                return false;
            }
            return true;
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
