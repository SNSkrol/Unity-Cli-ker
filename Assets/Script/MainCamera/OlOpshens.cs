using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class OlOpshens : MonoBehaviour
{
    public GameObject settings;
    public GameObject ShopPlayer;
    public GameObject ShopSecondBonus1;
    public GameObject locate;

    public Text moneytext;
    public Text bonusLevel1;
    public Text bonusLevel10;
    public Text bonusLevel100;
    public Text bonusLevelSecond1;

  

    public bool WorkGame;

    private SaveGameElement FileSaveGame = new SaveGameElement();
    private string pathToFileSaveGame;

    public void OnClick()
    {
        FileSaveGame.money += FileSaveGame.bonusLevel;
        MoneyDisplay(FileSaveGame.money);
    }

    private void MoneyDisplay(int money)
    {
        moneytext.text = money + "$";
    }
    
    private void Start()
    {
        pathToFileSaveGame = Path.Combine(Application.persistentDataPath , "FileSaveGame.json");
        WorkGame = true;
        if (File.Exists(pathToFileSaveGame))
        {
            FileSaveGame = JsonUtility.FromJson<SaveGameElement>(File.ReadAllText(pathToFileSaveGame));
        }
        else
        {
            FileSaveGame.money = 0;
            FileSaveGame.price1 = 20;
            FileSaveGame.pricePass1 = 20;

            FileSaveGame.bonusLevel = 1;
            FileSaveGame.moneyPerSecond = 0;
        }
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (WorkGame)
        {
            FileSaveGame.money += FileSaveGame.moneyPerSecond;
            MoneyDisplay(FileSaveGame.money);
            yield return new WaitForSeconds(1f);
        }
    }

    public void OnApplicationQuit()
    {
        WorkGame = false;
        File.WriteAllText(pathToFileSaveGame, JsonUtility.ToJson(FileSaveGame));
        Application.Quit();
            
    }
    public void OnOffSound()
    {
        OnOfSound.OnOffSounds = !OnOfSound.OnOffSounds;
    }
    
    public void OnSettings()
    {
        locate.SetActive(false);
        ShopPlayer.SetActive(false);
        ShopSecondBonus1.SetActive(false);
        settings.SetActive(!settings.activeSelf);
    }

    public void OnLocate()
    {
        settings.SetActive(false);
        ShopPlayer.SetActive(false);
        ShopSecondBonus1.SetActive(false);
        locate.SetActive(!locate.activeSelf);
    }

    public void ShopPan()
    {
        locate.SetActive(false);
        settings.SetActive(false);
        ShopSecondBonus1.SetActive(false);
        ShopPlayer.SetActive(!ShopPlayer.activeSelf);
        TextEditorBonusLv(FileSaveGame.price1);
    }

    public void ShopSecond()
    {
        locate.SetActive(false);
        settings.SetActive(false);
        ShopPlayer.SetActive(false);
        ShopSecondBonus1.SetActive(!ShopSecondBonus1.activeSelf);
        bonusLevelSecond1.text = "купить +1 в секунду за " + FileSaveGame.pricePass1 + "\n техущий доход в секунду " + FileSaveGame.moneyPerSecond;
    }

    public void TextEditorBonusLv(int price)
    {
        bonusLevel1.text = "купить +1 за клик за " + price + "?\n текущий доход за клик- " + FileSaveGame.bonusLevel;
        bonusLevel10.text = "купить +10 за клик за " + (price * 10) + "?\n текущий доход за клик- " + FileSaveGame.bonusLevel;
        bonusLevel100.text = "купить +100 за клик за " + (price * 100) + "?\n текущий доход за клик- " + FileSaveGame.bonusLevel;
    }

    public void ShopButtonAddBonus1()
    {
        if (FileSaveGame.money >= FileSaveGame.price1)
        {
            FileSaveGame.bonusLevel++;
            FileSaveGame.money = FileSaveGame.money - FileSaveGame.price1;
            FileSaveGame.price1 = (int)(FileSaveGame.price1 * 1.7);
            TextEditorBonusLv(FileSaveGame.price1);
            MoneyDisplay(FileSaveGame.money);
        }
    }
   
    public void ShopButtonAddBonus2()
    {
        if (FileSaveGame.money >= FileSaveGame.price1)
        {
            FileSaveGame.bonusLevel += 10;
            FileSaveGame.money -= (FileSaveGame.price1 * 10);
            FileSaveGame.price1 = (int)(FileSaveGame.price1 * 118.58787649699997);
            TextEditorBonusLv(FileSaveGame.price1);
            MoneyDisplay(FileSaveGame.money);
        }
    }
    public void ShopButtonAddBonus3()
    {
        if (FileSaveGame.money >= FileSaveGame.price1)
        {
            FileSaveGame.bonusLevel += 100;
            FileSaveGame.money -= (FileSaveGame.price1 * 100);
            FileSaveGame.price1 = (int)(FileSaveGame.price1 * Mathf.Pow(1.7f, 100));
            TextEditorBonusLv(FileSaveGame.price1);
            MoneyDisplay(FileSaveGame.money);
        }
    }
   
    public void SecondBonus1()
    {
        if (FileSaveGame.money >= FileSaveGame.pricePass1)
        {
            FileSaveGame.moneyPerSecond++;
            FileSaveGame.money -= FileSaveGame.pricePass1;
            FileSaveGame.pricePass1 = (int)(FileSaveGame.pricePass1 * 1.7);
            bonusLevelSecond1.text = "купить +1 в секунду за " + FileSaveGame.pricePass1 + "\n техущий доход в секунду " + FileSaveGame.moneyPerSecond;
            MoneyDisplay(FileSaveGame.money);
        }
    }
}
[Serializable]
public class SaveGameElement
{
    public int money;
    public int price1;
    public int pricePass1;

    public int bonusLevel;
    public int moneyPerSecond;

}
