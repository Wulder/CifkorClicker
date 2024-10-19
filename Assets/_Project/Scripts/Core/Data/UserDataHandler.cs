using System;
using Unity.VisualScripting;



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
            if (amount < 0) newEnergy = 0;
            if (amount > _data.MaxEnergy) newEnergy = _data.MaxEnergy;
            _data.Energy = newEnergy;

            if (save)
                ClickerApplication.Instance.DataTransfer.SendJsonData(_data);

            OnChangeEnergy?.Invoke(_data.Energy);
        }

        public void AddEnergy(double amount)
        {
            SetEnergy(_data.Energy + amount);
        }

        public void RemoveEnergy(double amount)
        {
            SetEnergy(_data.Energy - amount);
        }

        public void UpdateLastJoinDate()
        {
            _data.LastJoinDate = DateTime.Now.ToString();
        }
        
        public void SetFirstJoin(bool b)
        {
            _data.IsFirstJoin = b;
        }
        
       
    }
}
