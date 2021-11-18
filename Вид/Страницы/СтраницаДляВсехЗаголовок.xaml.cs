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
using ЭлектронныйЖурналКурсовой.Вид.Окна;


namespace ЭлектронныйЖурналКурсовой.Вид.Страницы
{
    /// <summary>
    /// Логика взаимодействия для СтраницаДляВсехЗаголовок.xaml
    /// </summary>
    public partial class СтраницаДляВсехЗаголовок : Page
    {
        public СтраницаДляВсехЗаголовок()
        {
            InitializeComponent();
        }

        private void КнопкаАвторизации_Нажать(object sender, RoutedEventArgs e)
        {
            ОкноАвторизации окноАвторизации = new ОкноАвторизации();
            var ТекущееОкно = Window.GetWindow(this);
            ИнструментыДанных.ТекущийПользователь = null;
            окноАвторизации.Show();
            ТекущееОкно.Close();
        }
    }
}
