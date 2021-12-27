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

namespace ЭлектронныйЖурналКурсовой.Вид.Страницы
{
    /// <summary>
    /// Логика взаимодействия для СтраницаДляАдминимтратораДобавитьПредмет.xaml
    /// </summary>
    public partial class СтраницаДляАдминимтратораДобавитьПредмет : Page
    {
        public СтраницаДляАдминимтратораДобавитьПредмет()
        {
            InitializeComponent();
        }

        private void КнопкаСоздатьПредмет_Нажать(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new СтраницаДляАдминимтратораОсновнаяПанель());
        }

        private void КнопкаОтмена_Нажать(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new СтраницаДляАдминимтратораОсновнаяПанель());
        }
    }
}
