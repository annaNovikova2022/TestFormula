using testFormul.testFormul.Models;
using testFormul.testFormul.ViewModels;

namespace FormulsTest
{
    public class Tests
    {
        /// <summary>
        /// ѕроверка вычислени€ линейной формулы
        /// </summary>
        [Test]
        public void TestLinearFormula()
        {
            var formula = new FormulaModel(1, "Linear");
            var foundValue = new FoundFormulasValueModel(formula);

            foundValue.X = 2;
            foundValue.Y = 3;

            if (foundValue.F == 4)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Warn("Wrong answer for linear");
            };
        }

        /// <summary>
        /// ѕроверка вычислени€ квадратичной формулы
        /// </summary>
        [Test]
        public void TestQuadraticFormula()
        {
            var formula = new FormulaModel(2, "Quadratic");
            var foundValue = new FoundFormulasValueModel(formula);

            foundValue.X = 2;
            foundValue.Y = 3;

            formula.A = 5;

            if (foundValue.F == 33)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Warn("Wrong answer for quadratic");
            };
        }

        /// <summary>
        /// ѕроверка вычислени€ кубической формулы
        /// </summary>
        [Test]
        public void TestCubicFormula()
        {
            var formula = new FormulaModel(3, "Cubic");
            var foundValue = new FoundFormulasValueModel(formula);

            foundValue.X = 2;
            foundValue.Y = 3;

            formula.A = 5;
            formula.B = 2;

            if (foundValue.F == 158)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Warn("Wrong answer for cubic");
            };
        }

        /// <summary>
        /// ѕроверка вычислени€ формулы 4-й степени
        /// </summary>
        [Test]
        public void TestFourDegreeFormula()
        {
            var formula = new FormulaModel(4, "FourDegree");
            var foundValue = new FoundFormulasValueModel(formula);

            foundValue.X = 2;
            foundValue.Y = 3;

            formula.A = 5;
            formula.B = 2;
            formula.CurrentC = formula.ListC[2];

            if (foundValue.F == 3134)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Warn("Wrong answer for four Degree");
            };
        }

        /// <summary>
        /// ѕроверка вычислени€ формулы 5-й степени
        /// </summary>
        [Test]
        public void TestFiveDegreeFormula()
        {
            var formula = new FormulaModel(5, "FiveDegree");
            var foundValue = new FoundFormulasValueModel(formula);

            if (foundValue.F == 10002)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Warn("Wrong answe for five Degree");
            };
        }

        /// <summary>
        /// ѕроверка вычислени€ формулы с отрицательными значени€ми
        /// </summary>
        [Test]
        public void TestNegativeNumbersFormula()
        {
            var formula = new FormulaModel(2, "Quadratic");
            var foundValue = new FoundFormulasValueModel(formula);

            foundValue.X = -2;
            foundValue.Y = -3;

            formula.A = 5;
            formula.B = -2;
            formula.CurrentC = formula.ListC[1];

            if (foundValue.F == 46)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Warn("Wrong answer with negative values");
            };
        }

        /// <summary>
        /// ѕроверка вычислени€ формулы с нулевыми значени€ми
        /// </summary>
        [Test]
        public void TestZeroFormula()
        {
            var formula = new FormulaModel(2, "Quadratic");
            var foundValue = new FoundFormulasValueModel(formula);

            foundValue.X = 0;
            foundValue.Y = 0;

            formula.A = 0;
            formula.B = 0;
            formula.CurrentC = formula.ListC[1];

            if (foundValue.F == 20)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Warn("Wrong answer with zero values");
            };
        }

        /// <summary>
        /// ѕроверка вычислени€ формулы с нецелыми значени€ми
        /// </summary>
        [Test]
        public void TestNonIntegersFormula()
        {
            var formula = new FormulaModel(1, "Linear");
            var foundValue = new FoundFormulasValueModel(formula);

            foundValue.X = 2.0f;
            foundValue.Y = 3.0f;

            formula.A = 1.0f;
            formula.B = 1.0f;

            if (foundValue.F == 4)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Warn("Wrong answer with Non-Integers values");
            };
        }

        /// <summary>
        /// ѕроверка добавлени€ нового найденного значени€ в коллекцию найденных значений
        /// </summary>
        [Test]
        public void TestAddValues()
        {
            var mainWindow = new MainWindowModelView();
            var CountOfFoundValues = mainWindow.SelectFoundFormulasValues.Count;

            mainWindow.SelectFoundFormulasValue = mainWindow.SelectFoundFormulasValues[0];
            mainWindow.AddCommand.Execute(mainWindow.SelectFoundFormulasValue);

            if (CountOfFoundValues == mainWindow.SelectFoundFormulasValues.Count - 1)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Warn("Error in the add command");
            };
        }

        /// <summary>
        /// ѕроверка удалени€ одного найденного значени€ из коллекции найденных значений
        /// </summary>
        [Test]
        public void TestDeleteValues()
        {
            var mainWindow = new MainWindowModelView();
            var CountOfFoundValues = mainWindow.SelectFoundFormulasValues.Count;

            mainWindow.SelectFoundFormulasValue = mainWindow.SelectFoundFormulasValues[1];
            mainWindow.DelCommand.Execute(mainWindow.SelectFoundFormulasValue);

            if (CountOfFoundValues == mainWindow.SelectFoundFormulasValues.Count + 1)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Warn("Error in the delete command");
            };
        }

        /// <summary>
        /// ѕроверка удалени€ всех найденных значений из коллекции найденных значений
        /// ƒолжно остатьс€ 1 значение
        /// </summary>
        [Test]
        public void TestDeleteAllValues()
        {
            var mainWindow = new MainWindowModelView();
            var CountOfFoundValues = mainWindow.SelectFoundFormulasValues.Count;

            for (int i = 1; i < CountOfFoundValues; i++)
            {
                mainWindow.SelectFoundFormulasValue = mainWindow.SelectFoundFormulasValues[1];
                mainWindow.DelCommand.Execute(mainWindow.SelectFoundFormulasValue);
            }
            mainWindow.DelCommand.Execute(mainWindow.SelectFoundFormulasValues[0]);

            if (mainWindow.SelectFoundFormulasValues.Count == 1)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Warn("Error in the delete command: all values was deleted");
            };
        }
    }
}