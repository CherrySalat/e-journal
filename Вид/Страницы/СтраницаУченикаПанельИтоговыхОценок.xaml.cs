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
    /// Логика взаимодействия для СтраницаУченикаПанельИтоговыхОценок.xaml
    /// </summary>
    public partial class СтраницаУченикаПанельИтоговыхОценок : Page
    {

        public СтраницаУченикаПанельИтоговыхОценок()
        {
            InitializeComponent();
            ПанельИнформацииОценки.ItemsSource =

                (from оценка in ИнструментыДанных.ЭлектронныйЖурнал.оценки
                 join предметы in ИнструментыДанных.ЭлектронныйЖурнал.предмет
                 on оценка.предмет equals предметы.номер_предмета
                 where оценка.ученик == ИнструментыДанных.ТекущийПользователь.номер 
                       
                 select new { предмет = предметы.предмет1, оценка = оценка.оценка }
                 ).Distinct().ToList();

        }

        private void КнопкаНазад_Нажать(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
