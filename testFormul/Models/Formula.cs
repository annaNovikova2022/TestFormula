namespace testFormula.testFormula.Models
{
    internal class Formula : BaseNotify
    {
        private string _name;
        private float _degreeX;
        private float _degreeY;
        private float _a;
        private float _b;
        private int? _currentC;
        private List<int> _c;

        public Action Changes { get; set; }

        public float A
        {
            get => _a;
            set
            {
                SetField(ref _a, value);
                Changes.Invoke();
            }
        }
        public float B
        {
            get => _b;
            set
            {
                SetField(ref _b, value);
                Changes.Invoke();
            }
        }
        public int CurrentC
        {
            get => (int)_currentC;
            set
            {
                SetField(ref _currentC, value);
                Changes.Invoke();
            }
        }
        public string Name => _name;
        public float DegreeX => _degreeX;
        public float DegreeY => _degreeY;
        public List<int> ListC => _c;
        
        public Formula(float degreeX, float degreeY, List<int> c, string name)
        {
            _degreeX = degreeX; 
            _degreeY = degreeY; 
            _name = name;
            _c = c;

            _currentC = c[0];
            _a = 1;
            _b = 1;
        }
    }
}
