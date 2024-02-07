using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour
{
    public TextMeshProUGUI BankMoneyText;
    public TextMeshProUGUI MoneyText;
    public TMP_InputField amountInput;
    public Button DepositButton;
    public Button withdrawButton;
    [SerializeField] private GameObject Error;

    public float BankMoney;
    public float Money;

    private void Start()
    {
        UpdateMoneyText();
        UpdateBankMoneyText();
    }

    //입금
    public void Deposit()
    {
        if (float.TryParse(amountInput.text, out float depositAmount))
        {
            if (depositAmount <= Money)
            {
                Money -= depositAmount;
                BankMoney += depositAmount;
                UpdateMoneyText();
                UpdateBankMoneyText();
            }
            else
            {
                Error.SetActive(true);
                Debug.Log("Not Enough Money");
            }
        }
        else
        {
            Error.SetActive(true);
            Debug.Log("Invalid Input for Deposit");
        }
    }

    //출금
    public void Withdraw()
    {
        if (float.TryParse(amountInput.text, out float withdrawAmount))
        {
            if (withdrawAmount <= BankMoney)
            {
                Money += withdrawAmount;
                BankMoney -= withdrawAmount;
                UpdateMoneyText();
                UpdateBankMoneyText();
            }
            else
            {
                Error.SetActive(true);
                Debug.Log("Not Enough Money in the Bank");
            }
        }
        else
        {
            Error.SetActive(true);
            Debug.Log("Invalid Input for Withdraw");
        }
    }

    public void UpdateBankMoneyText()
    {
        BankMoneyText.text = BankMoney.ToString("C2");
    }

    public void UpdateMoneyText()
    {
        MoneyText.text = Money.ToString("C2");
    }
}
