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
    /// Логика взаимодействия для СтраницаУчителяДобавитьОценку.xaml
    /// </summary>
    public partial class СтраницаУчителяДобавитьОценку : Page
    {
        bool режимИзминения = false;
        public СтраницаУчителяДобавитьОценку()
        {
            InitializeComponent();
        }

        public СтраницаУчителяДобавитьОценку(string Ученик, string Оценка)
        {
            InitializeComponent();
            ПолеУченик.Text = Ученик;
            ПолеОценка.Text = Оценка;
            режимИзминения = true;
        }



        private void КнопкаВыставитьОценку_Нажать(object sender, RoutedEventArgs e)
        {
            if(режимИзминения)
            {
                оценки оценка = ИнструментыДанных.ЭлектронныйЖурнал.оценки
                                                                        .Where(х=> х.номер_оценки)
            }
            else
            {
            
            }
        }
    }
}
