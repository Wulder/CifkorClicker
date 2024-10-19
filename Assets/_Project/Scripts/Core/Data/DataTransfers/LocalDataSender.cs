using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifkorClicker 
{
    public class LocalDataSender : IDataSender
    {
        private string DataKey = "UserData";
        public void SendData(string data)
        {
           PlayerPrefs.SetString(DataKey, data);
            PlayerPrefs.Save();
        }
    }
}
