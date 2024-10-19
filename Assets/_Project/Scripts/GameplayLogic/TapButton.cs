using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifkorClicker 
{
    public class TapButton : MonoBehaviour
    {
        private ClickerPropertiesSO _properites => ClickerApplication.Instance.Properties;
        private UserDataHandler _handler => ClickerApplication.Instance.UserDataHandler;
        public void Tap()
        {
            if(_handler.Data.Energy >= _properites.SpendEnergyForTap)
            {
                _handler.RemoveEnergy(_properites.SpendEnergyForTap);
                _handler.AddCoins(_properites.ProfitPerTap);
            }
            
        }
    }
}
