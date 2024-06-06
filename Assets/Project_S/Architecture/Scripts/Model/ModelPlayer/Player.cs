namespace Assets.Project_S
{
    public class Player : Character, IReadOnlyPlayer
    {
        private PlayerCharacterData _playerCharacterData;

        public Player(PlayerCharacterData characterData) : base(characterData) 
        {
            _playerCharacterData = (PlayerCharacterData)_characterData;
        }
    }
}
