
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CifkorClicker 
{
    public class TapButton : MonoBehaviour
    {
        private ClickerPropertiesSO _properites => ClickerApplication.Instance.Properties;
        private UserDataHandler _handler => ClickerApplication.Instance.UserDataHandler;

        [SerializeField] private List<TapModificator> _modificators = new List<TapModificator>();

        [SerializeField] private UnityEvent<double> OnTap;
        public void Tap()
        {
            if (_handler.Data.Energy >= _properites.SpendEnergyForTap)
            {
                _handler.RemoveEnergy(_properites.SpendEnergyForTap);

                double amount = _properites.GetCoinsPerTap();
                double modAmount = amount;
                foreach (var mod in _modificators)
                {
                    modAmount += mod.GetAddition(amount);
                }

                _handler.AddCoins(modAmount);
                OnTap?.Invoke(modAmount);
            }
            
        }

       
    }
}
 