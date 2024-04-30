using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PW6CSharpWPF.ViewModels
{
    public class MainWindowVM : ObservableCollection<MainWindowVM>
    {
        private DateTime _currentDate;
        private DaySelectionVM _selectedDay;
        private readonly Dictionary<DateTime, DaySelectionVM> _days;

        public ObservableCollection<DaySelectionVM> Days { get; set; }
        public DaySelectionVM SelectedDay
        {
            get => _selectedDay;
            set
            {
                _selectedDay = value;
                OnPropertyChanged(nameof(SelectedDay));
            }
        }

        public MainWindowVM()
        {
            Days = new ObservableCollection<DaySelectionVM>();
            _days = new Dictionary<DateTime, DaySelectionVM>();
            ContextMenu = new ContextMenu();

            OpenDayCommand = new RelayCommand(OpenDay);
            ClearDayCommand = new RelayCommand(ClearDay);
        }

        public void SetCurrentDate()
        {
            _currentDate = DateTime.Now;
            UpdateDays();
        }

        public void SelectedDateChanged()
        {
            _currentDate = CalendarControl.SelectedDate.Value;
            UpdateDays();
        }

        public void ShowContextMenu()
        {
            ContextMenu.IsOpen = true;
        }

        public void OpenDay()
        {
            if (SelectedDay != null)
            {
                NavigationService.Navigate(new SelectPage(SelectedDay));
            }
        }

        public void ClearDay()
        {
            if (SelectedDay != null)
            {
                SelectedDay.Items.Clear();
                UpdateDays();
            }
        }

        private void UpdateDays()
        {
            Days.Clear();
            DateTime startDate = new DateTime(_currentDate.Year, _currentDate.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            while (startDate <= endDate)
            {
                DaySelectionVM day = _days.GetValueOrDefault(startDate, new DaySelectionVM(startDate));
                Days.Add(day);

                if (day.Items.Count > 0)
                {
                    day.ItemIcon = day.Items[0].Icon;
                }

                _days[startDate] = day;
                startDate = startDate.AddDays(1);
            }
        }
    }
}


