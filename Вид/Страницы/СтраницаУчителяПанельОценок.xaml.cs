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
            СписокГруппПреподователя = ИнструментыДанных.ЭлектронныйЖурнал.учебная_группа
                                                        .Where(х => х.руководитель_группы == ТекущийПользователь.номер)
                                                        .Select(х => х.номер_группы)
                                                        .ToList();
            СписокГруппПреподователя = ИнструментыДанных.ЭлектронныйЖурнал.предмет
                                                        .Where(х => х.руководитель_группы == ТекущийПользователь.номер)
                                                        .Select(х => х.номер_группы)
                                                        .ToList();

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
