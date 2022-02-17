using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
  [SerializeField] int startingBalance = 150;
  [SerializeField] TextMeshProUGUI displayBalance;
  [SerializeField] TextMeshProUGUI depositAmount;
  [SerializeField] int currentBalance;
  public int CurrentBalance { get { return currentBalance; } }

  void Awake()
  {
    currentBalance = startingBalance;
    UpdateDisplay();
  }

  public void Deposit(int amount)
  {
    currentBalance += Mathf.Abs(amount);
    // depositAmount.text = $"+{amount}";
    // depositAmount.gameObject.SetActive(true);
    UpdateDisplay();
  }
  public void Withdraw(int amount)
  {
    currentBalance -= Mathf.Abs(amount);
    UpdateDisplay();

    if (currentBalance < 0)
    {
      //lose game
      ReloadScene();
    }
  }

  void ReloadScene()
  {
    Scene currentScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(currentScene.buildIndex);
  }

  void UpdateDisplay()
  {
    displayBalance.text = currentBalance.ToString();
  }
}
