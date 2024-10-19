using System;
using UnityEngine;
using UnityEngine.Events;

namespace CifkorClicker
{
    public class ClickerApplication : MonoBehaviour
    {
        //in real projects i will use DI, but in this example put all dependencies in this "God" class.

        private static ClickerApplication _instance;
        public static ClickerApplication Instance => _instance;

        [SerializeField] private ClickerPropertiesSO _properties;
        public ClickerPropertiesSO Properties => _properties;

        //initialize data about User
        private UserData _initializedUserData;
        public UserData InitializedUserData => _initializedUserData;

        //Data module for data working
        private DataTransfer _dataTransfer;
        public DataTransfer DataTransfer => _dataTransfer;

        //Module for handle data, can be in anywhere in the project, but i put this in ClickerApplication class
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
            data.MaxEnergy = _properties.MaxEnergy;
            data.LastJoinDate = DateTime.Now.ToString();
            data.IsFirstJoin = true;
            return data;
        }

        private void OnApplicationQuit()
        {
            _userDataHandler.UpdateLastJoinDate();
            _userDataHandler.SetFirstJoin(false);
            DataTransfer.SendJsonData(_userDataHandler.Data);
        }

    }
}
