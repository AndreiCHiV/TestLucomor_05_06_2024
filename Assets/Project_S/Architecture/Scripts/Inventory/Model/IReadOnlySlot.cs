using System;

namespace Assets.Project_S
{
    public interface IReadOnlyInventorySlot
    {
        event Action<string> ItemNameChanged;
        event Action<int> ItemIdChanged;
        event Action<int> ItemAmountChanged;
        event Action<float> ItemWeigthChanged;

        string Name { get; }
        int Id { get; }
        int Amount { get; }
        float Weigth { get; }
    }
}
