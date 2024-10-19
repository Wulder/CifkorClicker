
using UnityEngine;

namespace CifkorClicker
{
    [CreateAssetMenu(menuName = "AppProperties/ClickerProperties", fileName = "ClickerProperties")]
    public class ClickerPropertiesSO : ScriptableObject
    {
        [field: SerializeField] public double ProfitPerTap { get; private set; }
        
        
        

        [Tooltip("Time interval in seconds for get passive Income")]
        [field: SerializeField, Space(20),Header("PassiveIncome")] public double PassiveIncomeInterval { get; private set; }
        [field: SerializeField] public double StartPassiveIncome { get; private set; }

        [Tooltip("Time interval in seconds for recovery Energy")]
        [field: SerializeField, Space(20),Header("Energy")] public double MaxEnergy { get; private set; }
        [field: SerializeField] public double SpendEnergyForTap { get; private set; }
        [field: SerializeField] public double EnergyRecoveryInterval { get; private set; }
        [field: SerializeField] public double EnergyRecoveryAmount { get; private set; }

        
        [Tooltip("Tap modify")]
        [field: SerializeField, Space(20), Header("Tap modificator")] public double PerTapModify { get; private set; } = 1;
        [field: SerializeField] public double Divider { get; private set; }
        [field: SerializeField, Tooltip("Time for passive income in seconds")] public double T { get; private set; }
        public double GetCoinsPerTap()
        {
            return ProfitPerTap * GetMod();
        }

        public double GetMod()
        {
            return PerTapModify + (Divider * T * ClickerApplication.Instance.UserDataHandler.Data.PassiveIncome);
        }

    }
}