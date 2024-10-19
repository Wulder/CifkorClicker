using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifkorClicker
{
    public class UserDataHandler
    {
        public Action<double> OnAddCoins, OnRemoveCoins, OnChangeEnergy;
        public Action<UserData> OnIntialized;

        private UserData _data;
        public UserData Data => _data;

        public UserDataHandler()
        {
            ClickerApplication.Instance.OnGetInitializedUserData += OnDataInitialized;
        }

        public UserDataHandler(UserData data)
        {
            _data = data;
        }

        private void OnDataInitialized(UserData initData)
        {
            _data = initData;
            OnIntialized?.Invoke(initData);
        }

        public void AddCoins(double amount, bool save = true)
        {
            if (amount >= 0)
            {
                _data.Balance += amount;
            }

            if (save)
                ClickerApplication.Instance.DataTransfer.SendJsonData(_data);

            OnAddCoins?.Invoke(amount);
        }
        public void RemoveCoins(double amount, bool save = true)
        {
            //here must be logic for keep safe positive or zero balance but test task document hasn't info about it
            if (amount >= 0)
            {
                _data.Balance -= amount;
            }

            if (save)
                ClickerApplication.Instance.DataTransfer.SendJsonData(_data);

            OnAddCoins?.Invoke(amount);
        }
        public void SetEnergy(double amount, bool save = true)
        {
            double newEnergy = amount;
            if (newEnergy < 0) newEnergy = 0;
            if (newEnergy > _data.MaxEnergy) newEnergy = _data.MaxEnergy;
            _data.Energy = newEnergy;

            if (save)
                ClickerApplication.Instance.DataTransfer.SendJsonData(_data);
            OnChangeEnergy?.Invoke(newEnergy);
        }

        public void AddEnergy(double amount)
        {
            SetEnergy(_data.Energy + amount);
        }

        public void RemoveEnergy(double amount)
        {
            SetEnergy(_data.Energy - amount);
        }
    }
}
