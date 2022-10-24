using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public class AttackCommand : IAttackCommand
{
    public IAttackable Target { get; }

    public AttackCommand(IAttackable target) => Target = target;

}