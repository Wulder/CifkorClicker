using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifkorClicker
{
    [Serializable]
    public struct UserData
    {
        [SerializeField] private string _userId;
        [SerializeField] private double _balance;
        [SerializeField] private double _passiveProfit;

        public string UserID => _userId;
        public double Balance => _balance;
        public double PassiveProfit => _passiveProfit;
    }
}