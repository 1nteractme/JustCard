using Random = System.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script : MonoBehaviour
{
    private bool isClicked;
    [SerializeField] private TMP_Text UserGet;
    [SerializeField] private TMP_Text FreeMoney;
    [SerializeField] private TMP_InputField UserSet;

    public GameObject StartHidedMenu;
    public GameObject HidedMenu;

    public GameObject BacksideCard1;
    public GameObject BacksideCard2;
    public GameObject BacksideCard3;

    public GameObject FrontsideCardWin1;
    public GameObject FrontsideCardWin2;
    public GameObject FrontsideCardWin3;

    public GameObject CardLooseT11;
    public GameObject CardLooseT12;
    public GameObject CardLooseT13;

    public GameObject CardLooseT21;
    public GameObject CardLooseT22;
    public GameObject CardLooseT23;

    private int value2;
    private int test;

    private string Value;
    Random value = new Random();

    void Start()
    {
        FreeMoney.text = ($"available funds: {PlayerPrefs.GetInt("Value1")}$");

        for (uint ctr = 1; ctr <= 1; ctr++)
            Value = $"{value.Next(1, 4),1:N0}";
    }
    
    void Cup(string n, GameObject CardBackside, GameObject CardWin, GameObject CardLooseT1, GameObject CardLooseT2) // this script anylize user actions to cup
    {
        isClicked = true;

        if (isClicked)
        {
            if (n == Value)
            {
                CardBackside.SetActive(false);
                CardWin.SetActive(true);
                HidedMenu.SetActive(true);
                test = PlayerPrefs.GetInt("Value1") + int.Parse(UserSet.text.ToString());
                UserGet.text = ($"ñongratulations, you won {UserSet.text}$").ToString();
                PlayerPrefs.SetInt("Value1", test);
            }
            if (n != Value)
            {
                CardBackside.SetActive(false);
                HidedMenu.SetActive(true);

                if (Value == "1")
                {
                    CardLooseT1.SetActive(true);
                }
                else
                {
                    CardLooseT2.SetActive(true);
                }

                test = PlayerPrefs.GetInt("Value1") - int.Parse(UserSet.text);
                UserGet.text = ($"unfortunately, you lost {UserSet.text}$").ToString();
                PlayerPrefs.SetInt("Value1", test);
                
                PlayerPrefs.SetInt("Value1", test);
            }
        }
    }
    public void setCard1() // this script anylize user actions to cup
    {
        Cup("1", BacksideCard1, FrontsideCardWin1, CardLooseT11, CardLooseT21);
    }
    public void setCard2()
    {
        Cup("2", BacksideCard2, FrontsideCardWin2, CardLooseT12, CardLooseT22);
    }
    public void setCard3()
    {
        Cup("3", BacksideCard3, FrontsideCardWin3, CardLooseT13, CardLooseT23);
    }

    public void playMore()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void playNext()
    {

        value2 = PlayerPrefs.GetInt("Value1");
        PlayerPrefs.SetInt("Value1", value2);

        if (int.Parse(UserSet.text) == 0)
        {
            StartHidedMenu.SetActive(true);
            SceneManager.LoadScene("GameScene");
        }
        if (value2 - int.Parse(UserSet.text) < 0)
        {
            FreeMoney.text = $"your funds are not enough: {value2}$";
            StartHidedMenu.SetActive(true);
        }
        if (value2 - int.Parse(UserSet.text) >= 0)
        {
            StartHidedMenu.SetActive(false);
        }
    }
     
    public void Exit()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
