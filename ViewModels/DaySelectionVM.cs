using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PW6CSharpWPF.ViewModels
{
    public class DaySelectionVM : ObservableCollection<DaySelectionVM>
    {
        public DateTime Date { get; set; }
        public ObservableCollection<ItemVM> Items { get; set; }
        public ImageSource ItemIcon { get; set; }

        public DaySelectionVM(DateTime date)
        {
            Date = date;
            Items = new ObservableCollection<ItemVM>();
        }
    }
}
