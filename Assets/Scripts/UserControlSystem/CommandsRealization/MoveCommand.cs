using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public sealed class MoveCommand : IMoveCommand
    {
        public void Attack()
        {
            Debug.Log("Move");
        }
        //public Vector3 Target { get; }

        //public MoveCommand(Vector3 target)
        //{
        //    Target = target;
        //}
    }
}