using System;
using UnityEngine;

namespace CifkorClicker 
{
    public class PassiveIncome : MonoBehaviour
    {
        private ClickerPropertiesSO _properties => ClickerApplication.Instance.Properties;
        private UserDataHandler _handler => ClickerApplication.Instance.UserDataHandler;
        private float _timer;

        private void Awake()
        {
            if (!_handler.Data.IsFirstJoin)
                GivetOfflineIncome();
        }

        private void GivetOfflineIncome()
        {
            TimeSpan ts = DateTime.Now - DateTime.Parse(ClickerApplication.Instance.InitializedUserData.LastJoinDate);
            double totalSeconds = ts.TotalSeconds;
            double income = totalSeconds / _properties.PassiveIncomeInterval * _handler.Data.PassiveIncome;
            _handler.AddCoins(income);
            Debug.Log($"Add offline income for {totalSeconds / _properties.PassiveIncomeInterval}: {income} coins. Total seconds: {totalSeconds}");
        }
        void Update()
        {
            _timer += Time.deltaTime;
            if( _timer >= _properties.PassiveIncomeInterval)
            {
                GivePassiveIncome();
                _timer = 0;
            }
        }

        void GivePassiveIncome()
        {
            ClickerApplication.Instance.UserDataHandler.AddCoins(_properties.StartPassiveIncome);
        }
    }
}
