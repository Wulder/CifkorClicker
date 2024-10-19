using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CifkorClicker
{
    public class ClickerApplication : MonoBehaviour
    {
        //в боевых проектах вместо этого синглтона используем DI.
        //в данном случае класс ClickerApplication будет держать в себе ключевые модули для работы приложения

        private static ClickerApplication _instance;
        public static ClickerApplication Instance => _instance;

        [SerializeField] private ClickerPropertiesSO _properties;
        public ClickerPropertiesSO Properties => _properties;

        //информация о пользователе и его балансе
        private UserData _initializedUserData;
        public UserData InitializedUserData => _initializedUserData;

        //Data module for data working
        private DataTransfer _dataTransfer;
        public DataTransfer DataTransfer => _dataTransfer;

        //Module for handle data, can be in anywhere in the project, but i put this in ClcikerApplication class
        private UserDataHandler _userDataHandler;
        public UserDataHandler UserDataHandler => _userDataHandler;

        public Action<UserData> OnGetInitializedUserData;

        public UnityEvent OnInitialized;

        private void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
                Init();
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogWarning("Trying create other Application Object!");
                Destroy(this);
            }
        }
        
        private void Init()
        {
            //create local DataTransfer for handle playerPrefs
            _dataTransfer = new LocalDataTransfer();
            _userDataHandler = new UserDataHandler();
            _initializedUserData = _dataTransfer.ReceiveObjectFromJson<UserData>(GetDefaultData());
            OnGetInitializedUserData?.Invoke(_initializedUserData);
            OnInitialized?.Invoke();
        }

        private UserData GetDefaultData()
        {
            UserData data = new UserData();
            data.UserId = "User0";
            data.PassiveIncome = _properties.StartPassiveIncome;
            data.Balance = 0;
            data.Energy = _properties.MaxEnergy;
            return data;
        }

        
     
    }
}
