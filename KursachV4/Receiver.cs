//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KursachV4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Receiver
    {
        public Receiver()
        {
            this.Consumptions = new HashSet<Consumption>();
        }
    
        public int Id { get; set; }

        [Display(Name = "Назва фірми")]
        public string FirmTitle { get; set; }

        [Display(Name = "Код компанії")]
        public string CompanyCode { get; set; }

        [Display(Name = "Адреса")]
        public string Address { get; set; }

        [Display(Name = "Номер телефону")]
        public string Telephone { get; set; }

        [Display(Name = "Номер аккаунту")]
        public string Account { get; set; }

        [Display(Name = "Контактна людина")]
        public string ContactPerson { get; set; }


    
        public virtual ICollection<Consumption> Consumptions { get; set; }
    }
}
