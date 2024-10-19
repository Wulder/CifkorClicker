using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifkorClicker
{
    [CreateAssetMenu(menuName = "AppProperties/ClickerProperties", fileName = "ClickerProperties")]
    public class ClickerPropertiesSO : ScriptableObject
    {
        [field: SerializeField] public double ProfitPerTap { get; private set; }
        [field: SerializeField] public double SpendEnergyForTap { get; private set; }
        [field: SerializeField] public double StartPassiveIncome { get; private set; }
        [field: SerializeField] public double MaxEnergy { get; private set; }


    }
}