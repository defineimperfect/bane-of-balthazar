using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iinteractable
{
   public string InteractionPromt { get; }

    public bool Interact(Interactor interactor);
}
