using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifkorClicker
{
    public abstract class DataTransfer
    {
        protected IDataSender _sender;
        protected IDataReceiver _receiver;

        public virtual void Send(string data)
        {
            _sender.SendData(data);
        }

        public virtual string Receive()
        {
            return _receiver.ReceiveData();
        }
    }


    //интерфейсы дл€ создани€ разных реализаций отправлени€ и получени€ данных, например с сервера. 
    //¬ данном проекте будет использоватьс€ стандартный локальный PlayerPrefs. “ак же ограничимс€ в рамках проекта передачей данных в виде текста (string). ¬ боевых проектах нужна возможность передавать голые потоки байтов
    public interface IDataSender
    {
        public void SendData(string data);
    }

    public interface IDataReceiver
    {
        public string ReceiveData();
    }
}
