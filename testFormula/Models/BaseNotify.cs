using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace testFormul.testFormul.Models
{
    /// <summary>
    /// Класс для наследования функций интерфейса INotifyPropertyChanged
    /// </summary>
    public class BaseNotify : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие для изменяющихся значений
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Вызов события
        /// </summary>
        /// <param name="propertyName">Наименование значения</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Сравнение существующего и измененного значения
        /// </summary>
        /// <typeparam name="T">Тип рассматриваемых данных</typeparam>
        /// <param name="field">Существующее значение</param>
        /// <param name="value">Измененное значение</param>
        /// <param name="propertyName">Наименование значения</param>
        /// <returns></returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
