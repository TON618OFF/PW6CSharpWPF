using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PW6CSharpWPF.ViewModels
{
    public class ItemVM : ObservableCollection<ItemVM>
    {
        public string Name { get; set; }
        public ImageSource Icon { get; set; }
        public bool IsSelected { get; set; }
    }
}
