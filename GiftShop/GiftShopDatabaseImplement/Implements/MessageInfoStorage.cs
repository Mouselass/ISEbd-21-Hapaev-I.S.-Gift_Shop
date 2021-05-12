using System;
using System.Collections.Generic;
using System.Linq;
using GiftShopBusinessLogic.BindingModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;
using GiftShopDatabaseImplement.Models;

namespace GiftShopDatabaseImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        public List<MessageInfoViewModel> GetFullList()
        {
            using (var context = new GiftShopDatabase())
            {
                return context.MessageInfoes
                .Select(rec => new MessageInfoViewModel
                {
                    MessageId = rec.MessageId,
                    SenderName = rec.SenderName,
                    DateDelivery = rec.DateDelivery,
                    Subject = rec.Subject,
                    Body = rec.Body
                })
                .ToList();
            }
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new GiftShopDatabase())
            {
                return context.MessageInfoes
                .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
                    (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date))
                .Select(rec => new MessageInfoViewModel
                {
                    MessageId = rec.MessageId,
                    SenderName = rec.SenderName,
                    DateDelivery = rec.DateDelivery,
                    Subject = rec.Subject,
                    Body = rec.Body
                })
                .ToList();
            }
        }

        public void Insert(MessageInfoBindingModel model)
        {
            using (var context = new GiftShopDatabase())
            {
                MessageInfo element = context.MessageInfoes.FirstOrDefault(rec => rec.MessageId == model.MessageId);
                if (element != null)
                {
                    throw new Exception("Уже есть письмо с таким идентификатором");
                }
                context.MessageInfoes.Add(new MessageInfo
                {
                    MessageId = model.MessageId,
                    ClientId = model.ClientId,
                    SenderName = model.FromMailAddress,
                    DateDelivery = model.DateDelivery,
                    Subject = model.Subject,
                    Body = model.Body
                });
                context.SaveChanges();
            }
        }

        public int Count()
        {
            using (var context = new GiftShopDatabase())
            {
                return context.MessageInfoes.Count();
            }
        }

        public List<MessageInfoViewModel> GetMessagesForPage(MessageInfoBindingModel model)
        {
            using (var context = new GiftShopDatabase())
            {
                return context.MessageInfoes.Where(rec => (model.ClientId.HasValue &&
                model.ClientId.Value == rec.ClientId) || !model.ClientId.HasValue)
                    .Skip((model.Page.Value - 1) * model.PageSize.Value).Take(model.PageSize.Value)
                    .ToList().Select(rec => new MessageInfoViewModel
                    {
                        MessageId = rec.MessageId,
                        SenderName = rec.SenderName,
                        DateDelivery = rec.DateDelivery,
                        Subject = rec.Subject,
                        Body = rec.Body
                    }).ToList();
            }
        }
    }
}
