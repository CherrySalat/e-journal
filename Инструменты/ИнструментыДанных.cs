using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ЭлектронныйЖурналКурсовой.Данные;


namespace ЭлектронныйЖурналКурсовой.Инструменты
{
    public static class ИнструментыДанных
    {
       public static ЭлектронныйЖурналСущность ЭлектронныйЖурнал = new ЭлектронныйЖурналСущность();

       public static пользователи ТекущийПользователь;

        public static Image БайтыВКартику(byte[] Байты)
        {
            Image Картинка = new Image();
            MemoryStream читатель = new MemoryStream(Байты);
            Картинка.Source = BitmapFrame.Create(читатель, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

            return Картинка;
        }

    }
}
