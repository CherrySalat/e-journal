using System.Windows;
using System.Windows.Controls;
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
