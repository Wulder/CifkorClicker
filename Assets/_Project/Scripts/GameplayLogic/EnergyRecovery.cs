using System;
using UnityEngine;

namespace CifkorClicker
{
    public class EnergyRecovery : MonoBehaviour
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
            double energy = totalSeconds / _properties.EnergyRecoveryInterval * _properties.EnergyRecoveryAmount;
            _handler.AddEnergy(energy);
            Debug.Log($"Add offline energy for {totalSeconds / _properties.EnergyRecoveryInterval}: {_properties.EnergyRecoveryAmount} coins. Total seconds: {totalSeconds}");
        }
        void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _properties.EnergyRecoveryInterval)
            {
                RecoveryEnergy();
                _timer = 0;
            }
        }

        void RecoveryEnergy()
        {
            ClickerApplication.Instance.UserDataHandler.AddEnergy(_properties.EnergyRecoveryAmount);
        }
    }
}
