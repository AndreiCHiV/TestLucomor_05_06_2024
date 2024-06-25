using System;
using UnityEngine;

namespace Assets.Project_S
{
    public interface IReadOnlyDialogue
    {
        int DialogueId { get; }

        TextAsset GetDialogue();
    }
}
