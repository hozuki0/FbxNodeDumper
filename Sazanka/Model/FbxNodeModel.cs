using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sazanka.Model
{
    public class FbxNodeModel
    {
        public ReactiveCollection<string> Names { get; set; } = new ReactiveCollection<string>();
    }
}
