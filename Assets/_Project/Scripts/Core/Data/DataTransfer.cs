using System;
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

        public void SendJsonData<T>(T data)
        {
            
            _sender.SendData(JsonUtility.ToJson(data));
        }

        public T ReceiveObjectFromJson<T>(T defaultData)
        {
            string json = _receiver.ReceiveData();
            try
            {
                return JsonUtility.FromJson<T>(json);
            }
            catch(Exception ex)
            {
                Debug.Log(ex.Message);
                Debug.Log($"Failed to get {nameof(T)} type object, get default");
                return defaultData;
            }
            
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
