using System;
using System.Collections.Generic;
using System.Text;
using GiftShopBusinessLogic.Enums;
using GiftShopBusinessLogic.Attributes;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace GiftShopBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 100, visible: false)]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int? ImplementerId { get; set; }

        [DataMember]
        public int GiftId { get; set; }

        [DataMember]
        [Column(title: "Клиент", width: 150)]
        public string ClientFIO { get; set; }

        [DataMember]
        [Column(title: "Исполнитель", width: 150)]
        public string ImplementerFIO { get; set; }

        [DataMember]
        [Column(title: "Изделие", width: 150)]
        public string GiftName { get; set; }

        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }

        [DataMember]
        [Column(title: "Сумма", width: 50)]
        public decimal Sum { get; set; }

        [DataMember]
        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; }

        [DataMember]
        [Column(title: "Дата создания", width: 100, dateFormat: "D")]
        public DateTime DateCreate { get; set; }

        [DataMember]
        [Column(title: "Дата выполнения", width: 100, dateFormat: "D")]
        public DateTime? DateImplement { get; set; }
    }
}
