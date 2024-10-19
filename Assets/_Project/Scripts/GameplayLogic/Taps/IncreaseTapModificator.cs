
using UnityEngine;

namespace CifkorClicker 
{
    public class IncreaseTapModificator : TapModificator
    {
        private UserDataHandler _handler => ClickerApplication.Instance.UserDataHandler;

        [SerializeField] private double _percentOfPassiveIncome;
        public override double GetAddition(double sourceCount = 0)
        {
            return _handler.Data.PassiveIncome * _percentOfPassiveIncome;
        }
    }
}
