namespace testFormul.testFormul.Models
{
    /// <summary>
    /// Класс, содержащий в себе коэффициенты для определенной формулы
    /// </summary>
    internal class FormulaModel : BaseNotify
    {
        private string _name;
        private float _degreeX;
        private float _degreeY;
        private float _a;
        private float _b;
        private int? _currentC;
        private List<int> _c;

        /// <summary>
        /// Событие, вызывающиеся при измененении коэффициентов формулы
        /// </summary>
        public Action Changes { get; set; }
        /// <summary>
        /// Наименование формулы, степени Х и У, а так же список всех доступных значений С
        /// </summary>
        public string Name => _name;
        public float DegreeX => _degreeX;
        public float DegreeY => _degreeY;
        public List<int> ListC => _c;

        /// <summary>
        /// Чтение и изменение коэффициента А
        /// </summary>
        public float A
        {
            get => _a;
            set
            {
                SetField(ref _a, value);
                Changes.Invoke();
            }
        }
        /// <summary>
        /// Чтение и изменение коэффициента В
        /// </summary>
        public float B
        {
            get => _b;
            set
            {
                SetField(ref _b, value);
                Changes.Invoke();
            }
        }

        /// <summary>
        /// Чтение из списка С и изменение текущего коэффициента С
        /// </summary>
        public int CurrentC
        {
            get => (int)_currentC;
            set
            {
                SetField(ref _currentC, value);
                Changes.Invoke();
            }
        }

        /// <summary>
        /// Конструктор, задающий значения коэффициентов
        /// </summary>
        /// <param name="degreeX">Степень Х</param>
        /// <param name="degreeY">Степень У</param>
        /// <param name="c">Список доступных значений С</param>
        /// <param name="name">Наименование формулы</param>
        public FormulaModel(float degreeX, float degreeY, List<int> c, string name, float a = 1, float b = 1)
        {
            _degreeX = degreeX;
            _degreeY = degreeY;
            _name = name;
            _c = c;

            _currentC = c[0];
            _a = a;
            _b = b;
        }
    }
}
