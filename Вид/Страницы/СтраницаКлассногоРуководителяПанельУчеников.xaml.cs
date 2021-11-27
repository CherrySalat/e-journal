﻿using System;
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
    /// Логика взаимодействия для СтраницаКлассногоРуководителяПанельУчеников.xaml
    /// </summary>
    public partial class СтраницаКлассногоРуководителяПанельУчеников : Page
    {
        List<string> СписокПредметовПреподователя;        
        пользователи ТекущийПользователь;

        public СтраницаКлассногоРуководителяПанельУчеников()
        {
            InitializeComponent();
            ТекущийПользователь = ИнструментыДанных.ТекущийПользователь;
            СписокПредметовПреподователя = ИнструментыДанных.ЭлектронныйЖурнал.предмет
                                                                              .Where(х=>х.учебная_группа == ТекущийПользователь.учебная_группа)
                                                                              .Select(х=>х.предмет1)
                                                                              .ToList();            
            ПолеПредмет.ItemsSource = СписокПредметовПреподователя;
            
        }

        private void КнопкаПоказатьОценки_Нажать(object sender, RoutedEventArgs e)
        {
            ПанельОценок.ItemsSource = (from оценки in ИнструментыДанных.ЭлектронныйЖурнал.оценки
                                        join ученики in ИнструментыДанных.ЭлектронныйЖурнал.пользователи
                                        on оценки.ученик equals ученики.номер
                                        join предметы in ИнструментыДанных.ЭлектронныйЖурнал.предмет
                                        on оценки.предмет equals предметы.номер_предмета
                                        where 
                                               предметы.предмет1 == ПолеПредмет.Text &&
                                               ученики.учебная_группа == ТекущийПользователь.учебная_группа &&
                                               оценки.дата_получения == ПолеДатаОценки.SelectedDate
                                        select new { НомерОценки = оценки.номер_оценки, Ученик = ученики.фамилия + " " + ученики.имя + " " + ученики.отчество, Оценка = оценки.оценка }).ToList();
        
        }
    }
}
