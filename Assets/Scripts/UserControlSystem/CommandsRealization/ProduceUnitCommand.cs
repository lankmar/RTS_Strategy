using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;
using Zenject;

namespace UserControlSystem.CommandsRealization
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        
        [Inject(Id = "Orc")] public string UnitName { get;  }
        [Inject(Id = "Orc")] public Sprite Icon { get;  }
        [Inject(Id = "Orc")] public float ProductionTime { get;  }
        public GameObject UnitPrefab => _unitPrefab;


        [InjectAsset("Orc")] private GameObject _unitPrefab;
    }
}