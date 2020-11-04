using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Action OnRoadPlacement, OnHousePlacement, OnSpecialPlacement, OnBankPlacement, OnDestroyPlacement, OnEoliennePlacement;
    public Button placeRoadButton, placeHouseButton, placeSpecialButton, placeBankButton, placeDestroyButton, placeEoliennePlacement;

    public Color outlineColor;
    List<Button> buttonList;

    private void Start()
    {
        buttonList = new List<Button> { placeHouseButton, placeRoadButton, placeSpecialButton, placeBankButton, placeDestroyButton, placeEoliennePlacement };

        placeRoadButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeRoadButton);
            OnRoadPlacement?.Invoke();

        });
        placeHouseButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeHouseButton);
            OnHousePlacement?.Invoke();

        });
        placeSpecialButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeSpecialButton);
            OnSpecialPlacement?.Invoke();

        });
        placeBankButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeBankButton);
            OnBankPlacement?.Invoke();
        });
        placeDestroyButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeDestroyButton);
            OnDestroyPlacement?.Invoke();
        });
        placeEoliennePlacement.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeEoliennePlacement);
            OnEoliennePlacement?.Invoke();
        });
    }

    private void ModifyOutline(Button button)
    {
        var outline = button.GetComponent<Outline>();
        outline.effectColor = outlineColor;
        outline.enabled = true;
    }

    private void ResetButtonColor()
    {
        foreach (Button button in buttonList)
        {
            button.GetComponent<Outline>().enabled = false;
        }
    }
}
