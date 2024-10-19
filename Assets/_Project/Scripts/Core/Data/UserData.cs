using System;
using UnityEngine;

namespace CifkorClicker
{
    [Serializable]
    public struct UserData
    {
        [SerializeField] public string UserId;
        [SerializeField] public double Balance;
        [SerializeField] public double PassiveIncome;

        //parameters for saving current Energy of user and his potential maxEnergy if we will add this mechanic
        [SerializeField] public double Energy;
        [SerializeField] public double MaxEnergy;


        //last user's join to app
        [SerializeField] public string LastJoinDate;

        [SerializeField] public bool IsFirstJoin;
        
    }
}