using Abstractions;
using Abstractions.Commands;
using Zenject;
using System.Collections.Generic;
using UnityEngine;
namespace Core
{
    public sealed class OrcInstaller : MonoInstaller
    {
        //[SerializeField] private AttackerParrallelInfoUpdater _attackerParrallelInfoUpdater;
        //[SerializeField] private AttackerParrallelInfoUpdater attackerParrallelInfoUpdater;

        public override void InstallBindings()
        {
            Container.Bind<IHealthHolder>().FromComponentInChildren();
            Container.Bind<float>().FromComponentInChildren();
            Container.Bind<int>().FromComponentInChildren();
        }
    }
}