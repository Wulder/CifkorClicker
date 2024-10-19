
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CifkorClicker 
{
    public class UserDataUI : MonoBehaviour
    {
        private UserDataHandler _handler => ClickerApplication.Instance.UserDataHandler;
        private ClickerPropertiesSO _properties => ClickerApplication.Instance.Properties;

        [SerializeField] private TextMeshProUGUI _balacneTextField, _passiveIncomeTextField, _energyTextField;
        [SerializeField] private Image _energyFill;
        private void OnEnable()
        {
            _handler.OnAddCoins += OnChangeBalance;
            _handler.OnRemoveCoins += OnChangeBalance;
            _handler.OnChangeEnergy += SetEnergy;

            SetBalance(_handler.Data.Balance);
            SetPassiveIncome(_handler.Data.PassiveIncome);
            SetEnergy(_handler.Data.Energy);
        }

        private void OnDisable()
        {
            _handler.OnAddCoins -= OnChangeBalance;
            _handler.OnRemoveCoins -= OnChangeBalance;
            _handler.OnChangeEnergy -= SetEnergy;
        }
        private void OnChangeBalance(double amount)
        {
            SetBalance(_handler.Data.Balance);
        }

        private void OnInitializedData(UserData data)
        {
            SetBalance(data.Balance);
            SetPassiveIncome(data.PassiveIncome);
        }

        private void SetBalance(double amount)
        {
            _balacneTextField.text = amount.ToString("#.##");
        }
        private void SetPassiveIncome(double amount)
        {
            _passiveIncomeTextField.text = amount.ToString("#.##");
        }


        private void SetEnergy(double amount)
        {
            float maxEnergy = (float)_handler.Data.MaxEnergy;
            float energy = Mathf.Clamp((float)amount, 0, maxEnergy);
            if (maxEnergy <= 0)
            {
                return;
            }
            _energyFill.fillAmount = energy / maxEnergy;
            _energyTextField.text = $"{energy}/{maxEnergy}";
        }
    }
}
