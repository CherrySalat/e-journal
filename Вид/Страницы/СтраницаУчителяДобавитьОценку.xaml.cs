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
        пользователи                  ТекущийПользователь = ИнструментыДанных.ТекущийПользователь;
        оценки                        оценка;
        private readonly List<string> оценки         = new List<string>{ "н", "2", "3", "4", "5" };        
        private          string       предмет;
        private          DateTime     датаОценки;
        private          string       группа;

        private bool     режимИзминения = false;
        private int      номерОценки;
        private string[] ученикФИО;
        


        //Конструктор для добавления
        public СтраницаУчителяДобавитьОценку(string группа, string предмет, string датаОценки)
        {
            InitializeComponent();
            this.группа = группа;
            this.предмет = предмет;
            this.датаОценки = DateTime.Parse( датаОценки);
            ПолеУченик.ItemsSource = (from оценки in ИнструментыДанных.ЭлектронныйЖурнал.оценки
                                      join ученики in ИнструментыДанных.ЭлектронныйЖурнал.пользователи
                                      on оценки.ученик equals ученики.номер
                                      join предметы in ИнструментыДанных.ЭлектронныйЖурнал.предмет
                                      on оценки.предмет equals предметы.номер_предмета
                                      where ученики.группа == группа &&
                                             предметы.предмет1 == предмет &&
                                             предметы.преподователь == ИнструментыДанных.ТекущийПользователь.номер 
                                             
                                      select
                                          ученики.фамилия + " " + ученики.имя + " " + ученики.отчество
                                      ).ToList();


            ПолеОценка.ItemsSource = оценки;

        }


        //Конструктор для изминения оценки
        public СтраницаУчителяДобавитьОценку(int Номер)
        {
            InitializeComponent();
            оценка          = ИнструментыДанных.ЭлектронныйЖурнал.оценки.Where(х => х.номер_оценки == Номер).First();
            режимИзминения        = true;
            ПолеУченик.Visibility = Visibility.Hidden;
            ПолеУченикНадпись.Visibility = Visibility.Visible;
            ПолеУченикНадпись.Text = ИнструментыДанных.ЭлектронныйЖурнал.пользователи
                                                                 .Where(х => х.номер == оценка.ученик)
                                                                 .Select(х => х.фамилия + " " + х.имя + " " + х.отчество)
                                                                 .First();
            ПолеОценка.ItemsSource = оценки;
        }



        //TODO протестировать добавление новых оценок
        private void КнопкаВыставитьОценку_Нажать(object sender, RoutedEventArgs e)
        {
            //TODO заменить на условие при пустыз полях
            if (ПолеОценка.Text == "" && ПолеУченик.Text == "")
            {
                MessageBox.Show("Вы не до конца заполнили поля, проверьте данные на форме","Warning!!!", MessageBoxButton.OK, MessageBoxImage.Warning);                
                return;
            }

            //Изминение оценки
            if(режимИзминения)
            {
                оценка.оценка = ПолеОценка.Text;
                ИнструментыДанных.ЭлектронныйЖурнал.SaveChanges();
            }

            //Добавление оценки
            else
            {
                оценка = new оценки();
                оценка.оценка = ПолеОценка.Text;
                ученикФИО = ПолеУченик.Text.Split(' ');
                string фамилия = ученикФИО[0], имя = ученикФИО[1], отчество = ученикФИО[2];

                //TODO переделать                               
                оценка.ученик = ИнструментыДанных.ЭлектронныйЖурнал.пользователи.Where(х => х.имя == имя && х.фамилия == фамилия && х.отчество == отчество).Select(х=>х.номер).First();
                оценка.предмет = ИнструментыДанных.ЭлектронныйЖурнал.предмет.Where(х => х.преподователь == ИнструментыДанных.ТекущийПользователь.номер && х.предмет1 == предмет).Select(х => х.номер_предмета).First();               
                //TODO Реализовать выбор даты
                оценка.дата_получения = датаОценки;
                ИнструментыДанных.ЭлектронныйЖурнал.оценки.Add(оценка);
                ИнструментыДанных.ЭлектронныйЖурнал.SaveChanges();
            }

            NavigationService.Navigate(new СтраницаУчителяПанельОценок());
        }

        private void КнопкаОтмена_Нажать(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
