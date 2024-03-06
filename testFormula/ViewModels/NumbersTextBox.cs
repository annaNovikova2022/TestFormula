using System.Windows.Controls;
using System.Windows.Input;

namespace testFormul.myElements
{
    /// <summary>
    /// Класс для изменения ввода символов тектового поля только на числа
    /// </summary>
    public class NumbersTextBox: TextBox
    {
        /// <summary>
        /// Конструктор с присоединением проверки вводимого значения к событию
        /// </summary>
        public NumbersTextBox()
        {
            PreviewTextInput += NumbersPreviewTextInput;
        }

        /// <summary>
        /// Проверка вводимого символа
        /// </summary>
        /// <param name="sender">Объект, с которым происходит событие</param>
        /// <param name="e">Событие</param>
        private void NumbersPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Ваш код для проверки ввода и разрешения только числовых значений
            if (!IsNumericInput(e.Text))
            {
                e.Handled = true; // Предотвращаем ввод неправильных значений
            }
        }

        /// <summary>
        /// Проверка, что символ является числом
        /// </summary>
        /// <param name="input">Вводимый текст</param>
        /// <returns></returns>
        private bool IsNumericInput(string input)
        {
            if(input == "." && Text.Contains("."))
            {
                return false;
            }

            return (int.TryParse(input, out _) || input == ".");
        }
    }
}
