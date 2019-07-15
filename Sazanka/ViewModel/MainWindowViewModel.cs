using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Sazanka.Model;
using System.Reactive;
using System.Reactive.Subjects;
using Reactive.Bindings;
using Fbx;
using System.Linq;


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
        public ReactiveCollection<View.FbxNodeItem> Nodes => nodeModel.Nodes;

        public EventDispatchCommand Clear { get; private set; } = new EventDispatchCommand();

        public MainWindowViewModel()
        {
            Clear.OnEvent.Subscribe(_ =>
            {
                Nodes.Clear();
            });
        }

        public void Load(string path)
        {
            var rootNode = new View.FbxNodeItem(System.IO.Path.GetFileName(path));
            var content = FbxIO.ReadBinary(path);
            foreach (var item in content.Nodes.Where(n => n != null))
            {
                SeekNode(rootNode, item);
            }
            nodeModel.Nodes.Add(rootNode);
        }

        private void SeekNode(View.FbxNodeItem parent, FbxNode node)
        {
            var nodeItem = new View.FbxNodeItem(node.Name);
            parent.Items.Add(nodeItem);
            foreach (var item in node.Nodes.Where(n => n != null))
            {
                SeekNode(nodeItem, item);
            }
        }
    }
}
