namespace testFormul.testFormul.Models
{
    /// <summary>
    /// Класс, содержащий в себе коэффициенты для определенной формулы
    /// </summary>
    public class FormulaModel : BaseNotify
    {
        const int numOfListC = 5;

        private string _name;
        private int _degreeX;
        private int _degreeY;
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
        public int DegreeX => _degreeX;
        public int DegreeY => _degreeY;
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
        /// <param name="degree">Степень формулы и степень числа 10 для листа С</param>
        /// <param name="name">Наименование формулы</param>
        /// <param name="a">Коэффициент А</param>
        /// <param name="b">Коэффициент В</param>
        public FormulaModel(int degree, string name, float a = 1, float b = 1)
        {
            _degreeX = degree;
            _degreeY = degree-1;
            _name = name;
            _a = a;
            _b = b;

            _c = new List<int>();
            for (int i = 0; i < numOfListC; i++)
            {
                _c.Add((int)((i+1)*Math.Pow(10,degree-1)));
            }
            _currentC = _c[0];          
        }
    }
}
