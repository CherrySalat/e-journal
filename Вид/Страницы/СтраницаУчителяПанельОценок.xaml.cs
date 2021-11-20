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

        private void КнопкаПоказатьОценки_Нажать(object sender, RoutedEventArgs e)
        {

        }

        private void КнопкаСохранитьИзменения_Нажать(object sender, RoutedEventArgs e)
        {

        }
    
        private void КнопкаОтменитьИзминения_Нажать(object sender, RoutedEventArgs e)
        {

        }

        private void КнопкаДобавитьОценку_Нажать(object sender, RoutedEventArgs e)
        {

        }

        private void КнопкаУдалитьОценку_Нажать(object sender, RoutedEventArgs e)
        {

        }
    }
}
