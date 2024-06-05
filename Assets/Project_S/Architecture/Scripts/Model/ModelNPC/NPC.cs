namespace Assets.Project_S
{
    public class NPC : Character, IReadOnlyNPC
    {
        public NPC(CharacterData characterData) : base(characterData) { }
    }
}
