using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Values : MonoBehaviour
{
    [SerializeField] private TMP_Text PlayerGet;
    private int DefaultValue;
    private int value;
    private int value1;
    private int test;

    void Start()
    {
        test = PlayerPrefs.GetInt("Value1");
        PlayerGet.text = $"Credits: {test}$";
        //CountMoney();
    }

    public void StartGame() 
    {
        PlayerPrefs.SetInt("Value1", test);
        SceneManager.LoadScene("GameScene"); 
    }
    public void ClearData()
    {
        test = PlayerPrefs.GetInt("Value1");
        if (test == 0)
        { 
            PlayerPrefs.DeleteAll();
            test = 100;
            
        }
        else { test = 100; }
        PlayerPrefs.SetInt("Value1", test);
        SceneManager.LoadScene("SampleScene");
    }

}

