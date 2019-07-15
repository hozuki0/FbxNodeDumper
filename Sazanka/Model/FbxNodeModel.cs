using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sazanka.Model
{
    public class FbxNodeModel
    {
        public ReactiveCollection<View.FbxNodeItem> Nodes { get; set; } = new ReactiveCollection<View.FbxNodeItem>();
    }
}
