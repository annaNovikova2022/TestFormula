using System.Collections.ObjectModel;
using testFormul.testFormul.Models;

namespace testFormul.testFormul.ViewModels
{
    /// <summary>
    /// Класс для передачи данных между окном и моделями
    /// </summary>
    internal class MainWindowModelView : BaseNotify
    {
        private Formula _selectFormula;
        private FoundFormulasValue _selectFoundFormulasValue;
        private ObservableCollection<FoundFormulasValue> _selectFoundFormulasValues;

        private List<Formula> _formuls;
        private ObservableCollection<FoundFormulasValue> _foundFormulasValues; 
        private Dictionary<Formula, ObservableCollection<FoundFormulasValue>> _foundValueForFormuls;
        
        /// <summary>
        /// Чтение данных из листа формул, коллекции найденных значений и словаря формул и найденных значений 
        /// </summary>
        public List<Formula> Formuls => _formuls;
        public ObservableCollection<FoundFormulasValue> FoundFormulasValues => _foundFormulasValues;
        public Dictionary<Formula, ObservableCollection<FoundFormulasValue>> FoundValueForFormuls => _foundValueForFormuls;

        /// <summary>
        /// Чтение и запись текущей выбранной формулы, а так же изменение найденных значений
        /// </summary>
        public Formula SelectFormula
        {
            get => _selectFormula;
            set
            {
                SetField(ref _selectFormula, value);
                SelectFoundFormulasValues = FoundValueForFormuls[_selectFormula];
            }
        }
        /// <summary>
        /// Чтение и запись текущих найденных значений
        /// </summary>
        public ObservableCollection<FoundFormulasValue> SelectFoundFormulasValues
        {
            get => _selectFoundFormulasValues;
            set
            {
                SetField(ref _selectFoundFormulasValues, value);
                _foundFormulasValues = _selectFoundFormulasValues;
            }
        }
        /// <summary>
        /// Чтение и запись текущего выбранного найденного значения 
        /// </summary>
        public FoundFormulasValue SelectFoundFormulasValue
        {
            get => _selectFoundFormulasValue;
            set
            {
                SetField(ref _selectFoundFormulasValue, value);
            }
        }

        /// <summary>
        /// Команды для добавления и удаления вычислений
        /// </summary>
        public BaseCommand AddCommand { get; set; }
        public BaseCommand DelCommand { get; set; }

        /// <summary>
        /// Конструктор, где заполняются коэф-ты формул и словарь формул\найденных значений,
        /// тут же выбирается первое найденное значений и определяются команды добавления\удаления найденного значения
        /// </summary>
        public MainWindowModelView()
        {
            _formuls = new List<Formula>
            {
                new(1, 0, new List<int> { 1, 2, 3, 4, 5 }, "Линейная"),
                new(2, 1, new List<int> { 10, 20, 30, 40, 50 }, "Квадратичная"),
                new(3, 2, new List<int> { 100, 200, 300, 400, 500 }, "Кубическая"),
                new(4, 3, new List<int> { 1000, 2000, 3000, 4000, 5000 }, "4-й степени"),
                new(5, 4, new List<int> { 10000, 20000, 30000, 40000, 50000 }, "5-й степени"),

            };

            _foundValueForFormuls = new Dictionary<Formula, ObservableCollection<FoundFormulasValue>>()
            {
                {_formuls[0], new ObservableCollection<FoundFormulasValue> {new FoundFormulasValue(_formuls[0]), new FoundFormulasValue(_formuls[0])}},
                {_formuls[1], new ObservableCollection<FoundFormulasValue> {new FoundFormulasValue(_formuls[1])}},
                {_formuls[2], new ObservableCollection<FoundFormulasValue> {new FoundFormulasValue(_formuls[2])}},
                {_formuls[3], new ObservableCollection<FoundFormulasValue> {new FoundFormulasValue(_formuls[3])}},
                {_formuls[4], new ObservableCollection<FoundFormulasValue> {new FoundFormulasValue(_formuls[4])}},
            };

            SelectFormula = Formuls[0];

            AddCommand = new BaseCommand(_ => true, _ => Add());
            DelCommand = new BaseCommand(_ => _selectFoundFormulasValues.Count > 1, _ => Del());
        }

        /// <summary>
        /// Добавление нового найденного значения в коллекцию
        /// </summary>
        private void Add()
        {
            _selectFoundFormulasValues.Add(new FoundFormulasValue(_selectFormula));
        }

        /// <summary>
        /// Удаление найденного значения из коллекции
        /// </summary>
        private void Del()
        {
            _selectFoundFormulasValues.Remove(SelectFoundFormulasValue);
        }

    }
}
