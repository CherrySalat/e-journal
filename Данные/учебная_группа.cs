//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ЭлектронныйЖурналКурсовой.Данные
{
    using System;
    using System.Collections.Generic;
    
    public partial class учебная_группа
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public учебная_группа()
        {
            this.предмет = new HashSet<предмет>();
        }
    
        public string номер_группы { get; set; }
        public int руководитель_группы { get; set; }
    
        public virtual пользователи пользователи { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<предмет> предмет { get; set; }
    }
}
