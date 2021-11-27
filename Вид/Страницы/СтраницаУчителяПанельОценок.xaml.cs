using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ЭлектронныйЖурналКурсовой.Инструменты;
using ЭлектронныйЖурналКурсовой.Данные;

namespace ЭлектронныйЖурналКурсовой.Вид.Страницы
{
    /// <summary>
    /// Логика взаимодействия для СтраницаУчителяПанельОценок.xaml
    /// </summary>
    public partial class СтраницаУчителяПанельОценок : Page
    {
        List<string> СписокПредметовПреподователя;
        List<string> СписокГруппПреподователя;
        пользователи ТекущийПользователь;



        public СтраницаУчителяПанельОценок()
        {            
            InitializeComponent();
            ТекущийПользователь = ИнструментыДанных.ТекущийПользователь;
            СписокПредметовПреподователя = ИнструментыДанных.ЭлектронныйЖурнал.предмет
                                                                            .Where( х => х.преподователь == ТекущийПользователь.номер)
                                                                            .Select(х => х.предмет1)
                                                                            .ToList();
            СписокГруппПреподователя = (from группы in ИнструментыДанных.ЭлектронныйЖурнал.учебная_группа
                                        join предметы in ИнструментыДанных.ЭлектронныйЖурнал.предмет
                                        on группы.номер_группы equals предметы.группа
                                        where предметы.преподователь == ТекущийПользователь.номер
                                        select группы.номер_группы).ToList();




            ПолеПредмет.ItemsSource = СписокПредметовПреподователя;
            ПолеГруппа.ItemsSource  = СписокГруппПреподователя; 
        }

        private void УстановитьИсточник()
        {
            ПанельОценок.ItemsSource = (from оценки in ИнструментыДанных.ЭлектронныйЖурнал.оценки
                                        join ученики in ИнструментыДанных.ЭлектронныйЖурнал.пользователи
                                        on оценки.ученик equals ученики.номер
                                        join предметы in ИнструментыДанных.ЭлектронныйЖурнал.предмет
                                        on оценки.предмет equals предметы.номер_предмета
                                        where ученики.группа == ПолеГруппа.Text &&
                                               предметы.предмет1 == ПолеПредмет.Text &&
                                               предметы.преподователь == ТекущийПользователь.номер &&
                                               оценки.дата_получения == ПолеДатаОценки.SelectedDate
                                        select new { НомерОценки = оценки.номер_оценки, Ученик = ученики.фамилия + " " + ученики.имя + " " + ученики.отчество, Оценка = оценки.оценка }).ToList();
        }


        //Показываем оценки
        private void КнопкаПоказатьОценки_Нажать(object sender, RoutedEventArgs e)
        {
            if (ПолеПредмет.Text == null || ПолеГруппа.Text == "")
                MessageBox.Show("Выберете предмет по которому хотите видеть оценку", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            else
            {
                УстановитьИсточник();
            }
        }

        private void КнопкаДобавитьОценку_Нажать(object sender, RoutedEventArgs e)
        {
            if(ПолеПредмет.Text != "" && ПолеГруппа.Text != "" && ПолеПредмет.Text != null && ПолеГруппа.Text != null)
            NavigationService.Navigate(new СтраницаУчителяДобавитьОценку(ПолеГруппа.Text,ПолеПредмет.Text,DateTime.Now.ToString()));
        }

        private void КнопкаУдалитьОценку_Нажать(object sender, RoutedEventArgs e)
        {
            dynamic предНомерОценки = ПанельОценок.SelectedCells[0].Item;
            int НомерОценки;
            _ = int.TryParse(предНомерОценки, out НомерОценки);
            оценки удаляемаяОценка = ИнструментыДанных.ЭлектронныйЖурнал.оценки.Where(х => х.номер_оценки == НомерОценки).First();
            ИнструментыДанных.ЭлектронныйЖурнал.оценки.Remove(удаляемаяОценка);
            ИнструментыДанных.ЭлектронныйЖурнал.SaveChanges();
            УстановитьИсточник();

        }

        private void КнопкаИзменитьОценку_Нажать(object sender, RoutedEventArgs e)
        {
            dynamic предНомерОценки = ПанельОценок.SelectedCells[0].Item;
            int НомерОценки;
            _ = int.TryParse(предНомерОценки, out НомерОценки);
            NavigationService.Navigate(new СтраницаУчителяДобавитьОценку(НомерОценки));
        }
    }
}
