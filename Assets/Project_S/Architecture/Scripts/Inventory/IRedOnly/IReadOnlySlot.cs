using System;

namespace Assets.Project_S
{
    public interface IReadOnlyInventorySlot
    {
        public event Action<string> ItemNameChanged;
        public event Action<int> ItemIdChanged;
        event Action<int> ItemAmountChanged;
        event Action<float> ItemWeigthChanged;

        string Name { get; }
        int Id { get; }
        int Amount { get; }
        float Weigth { get; }
    }
}
