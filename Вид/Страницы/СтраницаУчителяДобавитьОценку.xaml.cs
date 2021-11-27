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
        private string   предмет;
        private DateTime   датаОценки;
        private string   группа;

        private bool     режимИзминения = false;
        private int      номерОценки;
        private string[] ученикФИО;
        
        //Конструктор для добавления
        public СтраницаУчителяДобавитьОценку(string группа, string предмет, string датаОценки)
        {
            InitializeComponent();
            //ученикФИО       = ученик.Split(' ');
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
                                             предметы.преподователь == ТекущийПользователь.номер 
                                             
                                      select
                                          ученики.фамилия + " " + ученики.имя + " " + ученики.отчество
                                      ).ToList();


            ПолеОценка.ItemsSource = оценки;

        }
        //Конструктор для изминения оценки
        public СтраницаУчителяДобавитьОценку(int Номер)
        {
            InitializeComponent();
            оценка          = ИнструментыДанных.ЭлектронныйЖурнал.оценки.First(х => х.номер_оценки == Номер);


            
            ПолеУченик.Text = ИнструментыДанных.ЭлектронныйЖурнал.пользователи
                                                                 .Where (х => х.номер == оценка.ученик)
                                                                 .Select(х => х.фамилия + х.имя[0] + х.отчество[0])
                                                                 .First ();
                                                                 
            ПолеОценка.Text       = оценка.оценка;
            ПолеУченик.IsReadOnly = true;
            режимИзминения        = true;


            ПолеОценка.ItemsSource = оценки;
        }





        //TODO протестировать добавление новых оценок
        private void КнопкаВыставитьОценку_Нажать(object sender, RoutedEventArgs e)
        {
            if (true)
                return;

            if(режимИзминения)
            {
                оценка.оценка = ПолеОценка.Text;
                ИнструментыДанных.ЭлектронныйЖурнал.SaveChanges();
            }

            else
            {
                оценка = new оценки();
                оценка.оценка = ПолеОценка.Text;
                ученикФИО = ПолеУченик.Text.Split(' ');

                //TODO переделать
                оценка.ученик = ИнструментыДанных.ЭлектронныйЖурнал.пользователи.Where(х => х.имя == ученикФИО[1] && х.фамилия == ученикФИО[0] && х.отчество == ученикФИО[2]).Select(х=>х.номер).First();
                
                
                //TODO Реализовать выбор даты
                оценка.дата_получения = DateTime.Now;
                ИнструментыДанных.ЭлектронныйЖурнал.оценки.Add(оценка);
                ИнструментыДанных.ЭлектронныйЖурнал.SaveChanges();
            }
        }
    }
}
