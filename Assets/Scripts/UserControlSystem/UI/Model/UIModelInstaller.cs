using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.UI.Model;
using Zenject;

namespace UserControlSystem
{
    public sealed class UIModelInstaller : MonoInstaller
    {
        [SerializeField] private Sprite _orcSprite;
        public override void InstallBindings()
        {
            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
                .To<ProduceUnitCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>()
                .To<AttackCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>()
                .To<MoveCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>()
                .To<PatrolCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>()
                .To<StopCommandCommandCreator>().AsTransient();

            Container.Bind<CommandButtonsModel>().AsTransient();

            Container.Bind<float>().WithId("Orc").FromInstance(5f);
            Container.Bind<string>().WithId("Orc").FromInstance("Orc");
            Container.Bind<Sprite>().WithId("Orc").FromInstance(_orcSprite);

            Container.Bind<BottomCenterModel>().AsTransient();
        }
    }
}