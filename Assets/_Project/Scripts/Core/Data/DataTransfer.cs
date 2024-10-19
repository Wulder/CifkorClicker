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


    //���������� ��� �������� ������ ���������� ����������� � ��������� ������, �������� � �������. 
    //� ������ ������� ����� �������������� ����������� ��������� PlayerPrefs. ��� �� ����������� � ������ ������� ��������� ������ � ���� ������ (string). � ������ �������� ����� ����������� ���������� ����� ������ ������
    public interface IDataSender
    {
        public void SendData(string data);
    }

    public interface IDataReceiver
    {
        public string ReceiveData();
    }
}
