using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для СтраницаДляВсехИнформацияОПользователе.xaml
    /// </summary>
    public partial class СтраницаДляВсехИнформацияОПользователе : Page
    {
        
        public СтраницаДляВсехИнформацияОПользователе()
        {
            InitializeComponent();
            пользователи пользователь = ИнструментыДанных.ТекущийПользователь;

            if (пользователь.фото == null)
                КнопкаДобавитьИзображение.Visibility = Visibility.Visible;
            else
            {
                КнопкаДобавитьИзображение.Visibility = Visibility.Hidden;
                Image картинка = new Image();
                картинка = ИнструментыДанных.БайтыВКартику(пользователь.фото);
                ФотоПрофиля.Source = картинка.Source;
            }


            ФИО.Text += $"{пользователь.фамилия} {пользователь.имя[0]}.{пользователь.отчество[0]}";
            ДатаРождения.Text += пользователь.дата_раждения.ToString("d");
            Должность.Text += пользователь.должность;
            Группа.Text += пользователь.группа == null ? "Отсутствует" : пользователь.группа;



        }

        private void ЗагрузитьИзображение(object sender, RoutedEventArgs e)
        {
            byte[] БайтовыйМассив;
            Image ЗагруженноеФотоПрофиля = new Image();
            string ПутьКФайлу = null;
            OpenFileDialog ОткрытьФайл = new OpenFileDialog();
            ОткрытьФайл.Filter = "Файлы изображений (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (ОткрытьФайл.ShowDialog() == true)            
                ПутьКФайлу = ОткрытьФайл.FileName;
            
            if (ПутьКФайлу != null)
            {
                БайтовыйМассив = File.ReadAllBytes(ПутьКФайлу);
                ИнструментыДанных.ТекущийПользователь.фото = БайтовыйМассив;
                ИнструментыДанных.ЭлектронныйЖурнал.SaveChanges();
                ЗагруженноеФотоПрофиля.Source = new BitmapImage(new Uri(ПутьКФайлу));
                ФотоПрофиля.Source = ЗагруженноеФотоПрофиля.Source;
            }

        }

    }
}
