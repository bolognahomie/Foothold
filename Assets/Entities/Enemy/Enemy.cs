using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] int goldReward = 25;
  [SerializeField] int goldPenalty = 25;
  [SerializeField] GameObject depositTextPrefab;
  [SerializeField] GameObject withdrawTextPrefab;

  Bank bank;

  void Start()
  {
    bank = FindObjectOfType<Bank>();
  }

  public void RewardGold()
  {
    if (bank == null) { return; }
    bank.Deposit(goldReward);
    GameObject tempDepositText = Instantiate(depositTextPrefab, transform.position, Quaternion.identity);
    tempDepositText.transform.GetComponent<TextMesh>().text = $"+{goldReward}";
  }
  public void StealGold()
  {
    if (bank == null) { return; }
    bank.Withdraw(goldPenalty);
  }
}
