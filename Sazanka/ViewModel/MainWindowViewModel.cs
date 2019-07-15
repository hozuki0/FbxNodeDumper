using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Sazanka.Model;
using System.Reactive;
using System.Reactive.Subjects;
using Reactive.Bindings;

namespace Sazanka.ViewModel
{
    public class EventDispatchCommand : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Subject<Unit> onEvent = new Subject<Unit>();
        public IObservable<Unit> OnEvent => onEvent;


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            onEvent.OnNext(Unit.Default);
        }
    }

    public class MainWindowViewModel
    {
        private FbxNodeModel nodeModel = new FbxNodeModel();
        public ReactiveCollection<string> NodeNames => nodeModel.Names;
        public EventDispatchCommand OnLoadClicked { get; } = new EventDispatchCommand();
        public ReactiveProperty<string> Path { get; set; } = new ReactiveProperty<string>("Default");

        public MainWindowViewModel()
        {
            OnLoadClicked.OnEvent.Subscribe(_ =>
            {
                Console.WriteLine($"OnLoad:{Path.Value}");
            });
        }
    }
}
