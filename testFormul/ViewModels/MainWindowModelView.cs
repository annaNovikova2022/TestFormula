using System.Collections.ObjectModel;
using testFormula.testFormula.Models;

namespace testFormula.testFormula.ViewModels
{
    internal class MainWindowModelView: BaseNotify
    {
        private Formula _selectFormula;
        private FoundFormulasValue _selectFoundFormulasValue;
        private ObservableCollection<FoundFormulasValue> _selectFoundFormulasValues;

        public List<Formula> Formuls { get; set; }
        public ObservableCollection<FoundFormulasValue> FoundFormulasValues { get; set; } //Переделать в private

        public Dictionary<Formula, ObservableCollection<FoundFormulasValue>> keyValues;
        
        public Formula CurrentFormula
        {
            get => _selectFormula;
            set 
            { 
                SetField(ref _selectFormula, value);
                CurrentFoundFormulasValues = keyValues[_selectFormula];
            }
        }

        public ObservableCollection<FoundFormulasValue> CurrentFoundFormulasValues
        {
            get => _selectFoundFormulasValues;
            set
            {
                SetField(ref _selectFoundFormulasValues, value);
                FoundFormulasValues = _selectFoundFormulasValues;
            }
        }

        public FoundFormulasValue CurrentFoundFormulasValue
        {
            get => _selectFoundFormulasValue;
            set
            {
                SetField(ref _selectFoundFormulasValue, value);
            }
        }

        public BaseCommand AddCommand { get; set; }
        public BaseCommand DelCommand { get; set; }

        public MainWindowModelView()
        {
            Formuls = new List<Formula>
            {
                new(1, 0, new List<int> { 1, 2, 3, 4, 5 }, "Линейная"),
                new(2, 1, new List<int> { 10, 20, 30, 40, 50 }, "Квадратичная"),
                new(3, 2, new List<int> { 100, 200, 300, 400, 500 }, "Кубическая"),
                new(4, 3, new List<int> { 1000, 2000, 3000, 4000, 5000 }, "4-й степени"),
                new(5, 4, new List<int> { 10000, 20000, 30000, 40000, 50000 }, "5-й степени"),

            };

            keyValues = new Dictionary<Formula, ObservableCollection<FoundFormulasValue>>()
            {
                {Formuls[0], new ObservableCollection<FoundFormulasValue> {new FoundFormulasValue(Formuls[0]), new FoundFormulasValue(Formuls[0])}},
                {Formuls[1], new ObservableCollection<FoundFormulasValue> {new FoundFormulasValue(Formuls[1])}},
                {Formuls[2], new ObservableCollection<FoundFormulasValue> {new FoundFormulasValue(Formuls[2])}},
                {Formuls[3], new ObservableCollection<FoundFormulasValue> {new FoundFormulasValue(Formuls[3])}},
                {Formuls[4], new ObservableCollection<FoundFormulasValue> {new FoundFormulasValue(Formuls[4])}},
            };

            CurrentFormula = Formuls[0];

            AddCommand = new BaseCommand(_ => true, _ => Add());
            DelCommand = new BaseCommand(_ => _selectFoundFormulasValues.Count > 1, _ => Del());
        }

        private void Add()
        {
            _selectFoundFormulasValues.Add(new FoundFormulasValue(_selectFormula));//
        }

        private void Del()
        {
            _selectFoundFormulasValues.Remove(CurrentFoundFormulasValue);
        }

    }
}
