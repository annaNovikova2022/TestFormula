
namespace testFormula.testFormula.Models
{
    internal class Coefficient: BaseNotify
    {
        private float _a;
        private float _b;
        private int? _currentC;
        private int[] _c;

        public float A
        {
            get => _a;
            set
            {
                SetField(ref _a, value);
            }
        }
        public float B
        {
            get => _b;
            set
            {
                SetField(ref _b, value);
            }
        }
        public int CurrentC
        {
            get => (int)_currentC;
            set
            {
                SetField(ref _currentC, value);
            }
        }

        
        public Coefficient(int[] c)
        {
            _c = c;

            _currentC = c[0];
            _a = 1;
            _b = 1;
        }
    }
}
