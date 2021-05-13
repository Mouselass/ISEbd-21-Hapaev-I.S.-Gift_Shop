using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using GiftShopBusinessLogic.Attributes;

namespace GiftShopBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }

        [DataMember]
        [Column(title: "Имя клиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFIO { get; set; }

        [DataMember]
        [Column(title: "Логин", width: 150)]
        public string Email { get; set; }

        [DataMember]
        [Column(title: "Пароль", width: 150)]
        public string Password { get; set; }
    }
}
