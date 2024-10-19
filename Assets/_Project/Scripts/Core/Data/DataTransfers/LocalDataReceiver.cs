using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifkorClicker 
{
    public class LocalDataReceiver : IDataReceiver
    {
        private string DataKey = "UserData";
        public string ReceiveData()
        {
            if(PlayerPrefs.HasKey(DataKey))
            {
                return PlayerPrefs.GetString(DataKey);
            }
            else
            {
                Debug.LogWarning($"Cant find {DataKey} key");
            }

            return string.Empty;
        }

        
    }
}
