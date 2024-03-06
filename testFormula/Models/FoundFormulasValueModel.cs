﻿namespace testFormul.testFormul.Models
{
    /// <summary>
    /// Данный класс позволяет находить и изменять значение функции
    /// </summary>
    public class FoundFormulasValueModel : BaseNotify
    {
        private float _x;
        private float _y;
        private double _f;
        private FormulaModel _formula;

        /// <summary>
        /// Для чтения коэфициентов текущей формулы
        /// </summary>
        public FormulaModel CurrentFormula => _formula;
        /// <summary>
        /// Для ввода и чтения значения Х
        /// </summary>
        public float X
        {
            get => _x;
            set
            {
                SetField(ref _x, value);
                CalculationFormula();
            }
        }
        /// <summary>
        /// Для ввода и чтения значения У
        /// </summary>
        public float Y
        {
            get => _y;
            set
            {
                SetField(ref _y, value);
                CalculationFormula();
            }
        }
        /// <summary>
        /// Для ввода и чтения значения функции
        /// </summary>
        public double F
        {
            get => _f;
            set
            {
                _f = value;
                OnPropertyChanged(nameof(F));
            }
        }
        /// <summary>
        /// Конструктор класса, где добавляется расчет F в событие объекта формулы и происходит сам расчет F 
        /// </summary>
        /// <param name="formula">Объект, содержащий в себе коэффициенты для формулы</param>
        public FoundFormulasValueModel(FormulaModel formula)
        {
            _formula = formula;
            _formula.Changes += CalculationFormula;

            _x = 1;
            _y = 1;
            CalculationFormula();
        }

        /// <summary>
        /// Расчет значения функции
        /// </summary>
        private void CalculationFormula()
        {
            F = _formula.A * Math.Pow(_x, _formula.DegreeX) + _formula.B * Math.Pow(_y, _formula.DegreeY) + _formula.CurrentC;
        }
    }
}
