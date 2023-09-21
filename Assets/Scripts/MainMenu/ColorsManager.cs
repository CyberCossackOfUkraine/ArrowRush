using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorsManager : MonoBehaviour
{
    [SerializeField] private Button[] _arrowColorButtons;
    [SerializeField] private Button[] _trailColorButtons;

    [SerializeField] private int colorCost;

    [SerializeField] private GameObject _popUpObject;


    private void Start()
    {
        ManageButtons();

        ManageButtonText();
    }

    private void ManageButtons()
    {
        for (int i = 0; i < 12; i++)
        {
            int x = i;
            _arrowColorButtons[i].onClick.AddListener(delegate { PopUpMessage(x, "Arrow"); });
            _trailColorButtons[i].onClick.AddListener(delegate { PopUpMessage(x, "Trail"); });
        }

        _popUpObject.transform.Find("PopUpPanel").transform.Find("NoButton").GetComponent<Button>()
            .onClick.AddListener(delegate { NoButton(); });
    }

    private void PopUpMessage(int number, string colorPart)
    {
        _popUpObject.transform.Find("PopUpPanel").transform.Find("YesButton").GetComponent<Button>()
            .onClick.AddListener(delegate { YesButton(number, colorPart); });

        if ((DataInfo.isArrowColorBought[number] && colorPart == "Arrow") || (DataInfo.isTrailColorBought[number] && colorPart == "Trail"))
        {
            _popUpObject.transform.Find("PopUpPanel").transform.Find("PopUpText").GetComponent<Text>()
                    .text = "Do you want to equip this color?";
        } else
        {
            _popUpObject.transform.Find("PopUpPanel").transform.Find("PopUpText").GetComponent<Text>()
                    .text = "Do you want to buy this color?\n" + colorCost + " coins";
        }



        _popUpObject.SetActive(true);
    }

    private void YesButton(int number, string colorPart)
    {
        if (colorPart == "Arrow")
        {
            if (DataInfo.isArrowColorBought[number])
            {
                // This Arrow Color is Already bought
                DataInfo.equippedArrowColor = number;
            } else
            {
                // This Arrow Color is NOT bought
                if (DataInfo.money >= colorCost)
                {
                    DataInfo.money -= colorCost;
                    DataInfo.isArrowColorBought[number] = true;
                }
            }
        } else
        {
            if (DataInfo.isTrailColorBought[number])
            {
                // This Trail Color is Already bought
                DataInfo.equippedTrailColor = number;
            }
            else
            {
                // This Trail Color is NOT bought
                if (DataInfo.money >= colorCost)
                {
                    Debug.Log("WHAT");
                    DataInfo.money -= colorCost;
                    DataInfo.isTrailColorBought[number] = true;
                }
            }
        }

        DataInfo.Save();

        _popUpObject.transform.Find("PopUpPanel").transform.Find("YesButton").GetComponent<Button>()
            .onClick.RemoveAllListeners();

        ManageButtonText();

        _popUpObject.SetActive(false);
    }

    private void NoButton()
    {
        _popUpObject.SetActive(false);
        Debug.Log("Equipped " + DataInfo.equippedArrowColor);
    }
    

    private void ManageButtonText()
    {
        for (int i = 0; i < 12; i++)
        {
            if (DataInfo.isArrowColorBought[i])
            {
                _arrowColorButtons[i].transform.Find("Text").GetComponent<Text>().text = "";
            }
            else
            {
                _arrowColorButtons[i].transform.Find("Text").GetComponent<Text>().text = colorCost.ToString() ;
            }

            if (DataInfo.isTrailColorBought[i])
            {
                _trailColorButtons[i].transform.Find("Text").GetComponent<Text>().text = "";
            }
            else
            {
                _trailColorButtons[i].transform.Find("Text").GetComponent<Text>().text = colorCost.ToString();
            }
        }

        _arrowColorButtons[DataInfo.equippedArrowColor].transform.Find("Text").GetComponent<Text>()
            .text = "SEL";
        _trailColorButtons[DataInfo.equippedTrailColor].transform.Find("Text").GetComponent<Text>()
            .text = "SEL";
    }

}
