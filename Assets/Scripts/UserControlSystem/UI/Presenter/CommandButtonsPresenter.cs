using System;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
//using UserControlSystem.CommandsRealization;
using UserControlSystem.UI.View;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private SelectableValue _selectable;
        [Inject] private CommandButtonsModel _model;
        private ISelectable _currentSelectable;

        private void Start()
        {
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;
            _model.OnCommandAccepted += _view.BlockInteractions;

            _selectable.OnSelected += ONSelected;
            ONSelected(_selectable.CurrentValue);
        }

        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }

            _currentSelectable = selectable;

            _view.Clear();

            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        private void ONButtonClick(ICommandExecutor commandExecutor)
        { 
            var unitProducer = commandExecutor as CommandExecuterBase<IProduceUnitCommand>;
            if (unitProducer != null)
            {
                unitProducer.ExecuteSpecificCommand(new ProduceUnitCommand());
                return;
            }
            throw new ApplicationException($"{nameof (CommandButtonsPresenter)}.{nameof(ONButtonClick)}: " + 
                $"Unknown type of commands executor {commandExecutor.GetType().FullName}!");
        }
    }
}