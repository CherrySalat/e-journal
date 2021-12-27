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
using ЭлектронныйЖурналКурсовой.Данные;
using ЭлектронныйЖурналКурсовой.Инструменты;

namespace ЭлектронныйЖурналКурсовой.Вид.Страницы
{
    /// <summary>
    /// Логика взаимодействия для СтраницаДляАдминимтратораДобавитьПользователя.xaml
    /// </summary>
    public partial class СтраницаДляАдминимтратораДобавитьПользователя : Page
    {
        List<string> списокДолжностей = new List<string>()  { "Ученик", "Учитель", "Классный руководитель", "Администратор " };
        
        public СтраницаДляАдминимтратораДобавитьПользователя()
        {
            InitializeComponent();
            ПолеДолжность.ItemsSource = списокДолжностей;
            ПолеГруппа.ItemsSource = ИнструментыДанных.ЭлектронныйЖурнал.учебная_группа.Select(х => х.номер_группы).ToList();
        }

        private void КнопкаОтмена_Нажать(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new СтраницаДляАдминимтратораОсновнаяПанель());
        }

        private void КнопкаСоздатьГруппу_Нажать(object sender, RoutedEventArgs e)
        {
            if (ПолеДатаРождения.SelectedDate == null
             || ПолеДолжность.Text            == ""
             || ПолеИмя.Text                  == ""
             || ПолеЛогин.Text                == ""
              
             || ПолеПароль.Text               == ""
             || ПолеПарольПовторить.Text      == ""
             || ПолеФамилия.Text              == "" 
             || ПолеПароль.Text               != ПолеПарольПовторить.Text )
            {
                MessageBox.Show("Не все поля заполнены", "Осторожно", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            пользователи новыйПользователь  = new пользователи();
            новыйПользователь.группа        = ПолеГруппа.Text;
            новыйПользователь.дата_раждения = (DateTime)ПолеДатаРождения.SelectedDate;
            новыйПользователь.должность     = ПолеДолжность.Text;
            новыйПользователь.имя           = ПолеИмя.Text;
            новыйПользователь.логин         = ПолеЛогин.Text;
            новыйПользователь.отчество      = ПолеОтчество.Text;
            новыйПользователь.пароль        = ПолеПароль.Text;
            новыйПользователь.фамилия       = ПолеФамилия.Text;
            ИнструментыДанных.ЭлектронныйЖурнал.пользователи.Add(новыйПользователь);
            ИнструментыДанных.ЭлектронныйЖурнал.SaveChanges();
            NavigationService.Navigate(new СтраницаДляАдминимтратораОсновнаяПанель());
        }
    }
}
