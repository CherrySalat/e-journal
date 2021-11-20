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
using System.Windows.Shapes;
using ЭлектронныйЖурналКурсовой.Данные;
using ЭлектронныйЖурналКурсовой.Инструменты;
using ЭлектронныйЖурналКурсовой.Вид.Окна;



namespace ЭлектронныйЖурналКурсовой.Вид.Окна
{
    /// <summary>
    /// Логика взаимодействия для ОкноАвторизации.xaml
    /// </summary>
    /// 



    public partial class ОкноАвторизации : Window
    {
        public static List<string> Роли = new List<string>()
        {
            "Учитель",
            "Ученик",
            "Классный руководитель",
            "Директор",
            "Администратор"
        };

        private Dictionary<string, Action> СловарьАвторизации = new Dictionary<string, Action>()
        {

        };

        public ОкноАвторизации()
        {
            InitializeComponent();
        }

        private void КнопкаАвторизации_Нажать(object sender, RoutedEventArgs e)
        {
            ПопыткаАвторизации();
        }

 



        private void ПопыткаАвторизации()
        {
            string логин = ПолеЛогин.Text;
            string пароль = ПолеПароль.Password;
            ИнструментыДанных.ТекущийПользователь = ИнструментыДанных.ЭлектронныйЖурнал.пользователи
                                                                      .Any(х => х.логин == логин && х.пароль == пароль) ?
                                                    ИнструментыДанных.ЭлектронныйЖурнал.пользователи
                                                                      .Where(х => х.логин == логин && х.пароль == пароль)
                                                                      .First() : null;

            if (ИнструментыДанных.ТекущийПользователь != null)
            {
                switch (ИнструментыДанных.ТекущийПользователь.должность)
                {
                    case "Учитель":
                        ОткрытьОкноУчителя();
                        break;

                    case "Ученик":
                        ОткрытьОкноУченика();
                        break;

                    case "Классный руководитель":
                        ОткрытьОкноКлассногоРуководителя();
                        break;
                    default:
                        break;
                }
            }
            else
                НапдписьНеверныйЛогинИлиПароль.Visibility = Visibility.Visible;
        }



        public void ОткрытьОкноУченика()
        {
            var окно = new ОкноУченика();
            окно.Show();
            Close();
        }

        private void ОткрытьОкноУчителя()
        {
            var окно = new ОкноУчителя();
            окно.Show();
            Close();
        }

        private void ОткрытьОкноКлассногоРуководителя()
        {
            var окно = new ОкноКлассногоРуководителя();
            окно.Show();
            Close();
        }














    }
}
