﻿using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IProduceUnitCommand : ICommand //IIconHolder
    {
        GameObject UnitPrefab { get; }
    }
}