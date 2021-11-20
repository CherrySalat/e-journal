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


        //Показываем оценки
        private void КнопкаПоказатьОценки_Нажать(object sender, RoutedEventArgs e)
        {
            if (ПолеПредмет.Text == null || ПолеГруппа.Text == "")
                MessageBox.Show("Выберете предмет по которому хотите видеть оценку", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            else
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
                                           select new {НомерОценки = оценки.номер_оценки, Ученик = ученики.фамилия+ " " + ученики.имя +" " + ученики.отчество, Оценка = оценки.оценка }).ToList();
            }
        }

        private void КнопкаДобавитьОценку_Нажать(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new СтраницаУчителяДобавитьОценку());
        }

        private void КнопкаУдалитьОценку_Нажать(object sender, RoutedEventArgs e)
        {
            //var столбец = ПанельОценок.SelectedItem;
            //var номерОценки = столбец.НомерОценки;
        }

        private void КнопкаИзменитьОценку_Нажать(object sender, RoutedEventArgs e)
        {



        }
    }
}
