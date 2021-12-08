using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ЭлектронныйЖурналКурсовой.Инструменты;
using ЭлектронныйЖурналКурсовой.Данные;
namespace ЭлектронныйЖурналКурсовой.Вид.Страницы
{
    /// <summary>
    /// Логика взаимодействия для СтраницаУченикаПанельОценок.xaml
    /// </summary>
    public partial class СтраницаУченикаПанельОценок : Page
    {
        пользователи ТекущийПользователь = ИнструментыДанных.ТекущийПользователь;
        List<string> СписокПредметов;
        

        public СтраницаУченикаПанельОценок()
        {
            InitializeComponent();
            СписокПредметов = (from пользователь        in ИнструментыДанных.ЭлектронныйЖурнал.пользователи
                               join группа              in ИнструментыДанных.ЭлектронныйЖурнал.учебная_группа
                               on пользователь.номер    equals группа.пользователи.номер
                               join предметы            in ИнструментыДанных.ЭлектронныйЖурнал.предмет
                               on группа.номер_группы   equals предметы.группа
                               select предметы.предмет1)
                              .Distinct().ToList();
            ПолеСписокПредметов.ItemsSource = СписокПредметов;
        }

        private void КнопкаПоказатьОценки_Нажать(object sender, RoutedEventArgs e)
        {

            if (ПолеСписокПредметов.Text == "")
                MessageBox.Show("Выберете предмет по которому хотите видеть оценку", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            else           
                ПанельИнформацииОценки.ItemsSource = ИнструментыДанных.ЭлектронныйЖурнал.оценки
                                                                                         .Where (х => х.пользователи.номер == ТекущийПользователь.номер)
                                                                                         .Select(х => new { ДатаОценки = х.дата_получения.ToString(), Оценка = х.оценка })
                                                                                         .ToList();
            
        }

        private void КнопкаПоказатьИтоговыеОценки_Нажать(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new СтраницаУченикаПанельИтоговыхОценок());
        }
    }
}
