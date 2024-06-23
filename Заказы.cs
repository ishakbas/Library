//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library
{
    using System;
    using System.Collections.Generic;
    
    public partial class Заказы
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Заказы()
        {
            this.Детали_заказа = new HashSet<Детали_заказа>();
        }
    
        public int Номер_заказа { get; set; }
        public Nullable<System.Guid> Номер_сотрудника { get; set; }
        public Nullable<int> Номер_клиента { get; set; }
        public Nullable<int> Номер_статуса_заказа { get; set; }
        public Nullable<System.DateTime> Дата_заказа { get; set; }
        public Nullable<int> Номер_способа_оплаты { get; set; }
        public Nullable<decimal> Сумма_оплаты { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Детали_заказа> Детали_заказа { get; set; }
        public virtual Клиенты Клиенты { get; set; }
        public virtual Сотрудники Сотрудники { get; set; }
        public virtual Способы_оплаты Способы_оплаты { get; set; }
        public virtual Статусы_заказа Статусы_заказа { get; set; }
    }
}
