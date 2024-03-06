using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace testFormul.myElements
{
    /// <summary>
    /// Класс для изменения ввода символов ячейки таблицы только на числа
    /// </summary>
    class NumbersDataGridTextColumn : DataGridTextColumn
    {
        private TextBox? _editingElenent;
        
        /// <summary>
        /// Переопределение метода
        /// </summary>
        /// <param name="editingElement">Редактируемый элемент</param>
        /// <param name="editingEventArgs">Как элемент редактируется</param>
        /// <returns></returns>
        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            _editingElenent = editingElement as TextBox;

            if (_editingElenent != null) _editingElenent.PreviewTextInput += NumbersDataGridTextColumn_OnPreviewTextInput;

            return base.PrepareCellForEdit(editingElement, editingEventArgs);
        }

        /// <summary>
        /// Проверка вводимого символа
        /// </summary>
        /// <param name="sender">Объект, с которым происходит событие</param>
        /// <param name="e">Событие</param>
        private void NumbersDataGridTextColumn_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsNumericInput(e.Text))
                e.Handled = true;
        }

        /// <summary>
        /// Проверка, что символ является числом
        /// </summary>
        /// <param name="input">Вводимый текст</param>
        /// <returns></returns>
        private bool IsNumericInput(string input)
        {
            if ( input == "." && _editingElenent.Text.Contains("."))
            {
                return false;
            }

            return (int.TryParse(input, out _) || input == ".");
        }
    }
}
