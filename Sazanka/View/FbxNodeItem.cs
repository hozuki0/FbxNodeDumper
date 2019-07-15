using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sazanka.View
{
    public class FbxNodeItem : TreeViewItem
    {
        public FbxNodeItem(string name)
        {
            this.Header = name;
        }
    }
}
