using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifkorClicker
{
    [CreateAssetMenu(menuName = "AppProperties/ClickerProperties", fileName = "ClickerProperties")]
    public class ClickerPropertiesSO : ScriptableObject
    {
        [field: SerializeField] public double ProfitPerTap { get; private set; }
    }
}