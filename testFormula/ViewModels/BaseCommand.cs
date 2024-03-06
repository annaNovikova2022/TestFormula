using System.Windows.Input;

namespace testFormul.testFormul.ViewModels
{
    /// <summary>
    /// Класс для работы с интерфейсом ICommand
    /// </summary>
    public class BaseCommand : ICommand
    {
        private readonly Predicate<object?> _canExecute;
        private readonly Action<object?> _execute;

        /// <summary>
        /// Проверка: сможет ли каманда выполнится?
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Возвращает булево значение проверки</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        /// <summary>
        /// Вызов команды
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        public void Execute(object? parameter)
        {
            _execute.Invoke(parameter);
        }

        public event EventHandler? CanExecuteChanged;
        
        /// <summary>
        /// Конструктор для создания команды
        /// </summary>
        /// <param name="canExecute">Условие выполнения</param>
        /// <param name="execute">Функция выполнения</param>
        public BaseCommand(Predicate<object?> canExecute, Action<object?> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }
    }
}
