using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Abstractions.Commands
{
    public interface ICommandQueue
    {
        //ICommand CurrentCommand { get; }

        void EnqueueCommand(object command);

        void Clear();
    }
}