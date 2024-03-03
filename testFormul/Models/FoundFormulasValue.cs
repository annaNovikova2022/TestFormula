namespace testFormula.testFormula.Models
{
    internal class FoundFormulasValue: BaseNotify
    {
        private float _x;
        private float _y;
        private double _f;
        private Formula _formula;

        public float X
        {
            get => _x;
            set
            {
                SetField(ref _x, value);
                CalculationFormula();
            }
        }
        public float Y
        {
            get => _y;
            set
            {
                SetField(ref _y, value);
                CalculationFormula();
            }
        }
        public double F
        {
            get => _f;
            set
            {
                SetField(ref _f, value);
            }
        }
        
        public FoundFormulasValue(Formula formula)
        {
            _formula = formula;
            _formula.Changes += CalculationFormula;

            _x = 1; 
            _y = 1;
            CalculationFormula();
        }

        public void CalculationFormula()
        {
            _f = _formula.A * Math.Pow(_x, _formula.DegreeX) + _formula.B * Math.Pow(_y, _formula.DegreeY) + _formula.CurrentC;
        }
    }
}
