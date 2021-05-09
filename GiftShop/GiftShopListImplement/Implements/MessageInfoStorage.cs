using System;
using System.Collections.Generic;
using System.Text;
using GiftShopBusinessLogic.BindingModels;
using GiftShopBusinessLogic.ViewModels;
using GiftShopListImplement.Models;

namespace GiftShopListImplement.Implements
{
    public class MessageInfoStorage
    {
        private readonly DataListSingleton source;

        public MessageInfoStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();
            foreach (var messageInfo in source.MessageInfoes)
            {
                result.Add(CreateModel(messageInfo));
            }
            return result;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();
            foreach (var message in source.MessageInfoes)
            {
                if ((model.ClientId.HasValue && message.ClientId == model.ClientId) ||
                    (!model.ClientId.HasValue && message.DateDelivery.Date == model.DateDelivery.Date))
                {
                    result.Add(CreateModel(message));
                }
            }
            if (result.Count > 0)
            {
                return result;
            }
            return null;
        }

        public void Insert(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            source.MessageInfoes.Add(CreateModel(model, new MessageInfo()));
        }

        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo messageInfo)
        {
            string clientName = string.Empty;
            foreach (var client in source.Clients)
            {

                if (client.Id == model.ClientId)
                {
                    clientName = client.ClientFIO;
                    break;
                }
            }
            messageInfo.SenderName = clientName;
            messageInfo.Subject = model.Subject;
            messageInfo.ClientId = model.ClientId;
            messageInfo.Body = model.Body;
            messageInfo.DateDelivery = model.DateDelivery;
            return messageInfo;
        }

        private MessageInfoViewModel CreateModel(MessageInfo messageInfo)
        {
            return new MessageInfoViewModel
            {
                MessageId = messageInfo.MessageId,
                SenderName = messageInfo.SenderName,
                Subject = messageInfo.Subject,
                Body = messageInfo.Body,
                DateDelivery = messageInfo.DateDelivery
            };
        }
    }
}
