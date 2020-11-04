using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Action OnRoadPlacement, OnHousePlacement, OnDestroyPlacement, OnEoliennePlacement, OnBuildingPlacement, OnEcoBuildingPlacement, OnPolicePlacement, OnTrashPlacement, OnEcoTrashPlacement,
                  OnBikePlacement, OnCoalPlacement, OnVoltaPlacement, OnFirePlacement;
    public Button placeRoadButton, placeHouseButton, placeDestroyButton, placeEolienneBt, placeBuildingBt, placeEcoBuildingBt, placePoliceBt, placeTrashBt, placeEcoTrashBt,
                  placeBikeBt, placeCoalBt, placeVoltaBt, placeFireBt;

    public Color outlineColor;
    List<Button> buttonList;

    private void Start()
    {
        buttonList = new List<Button> { placeRoadButton, placeHouseButton, placeDestroyButton, placeEolienneBt, placeBuildingBt, placeEcoBuildingBt, placePoliceBt, placeTrashBt, placeEcoTrashBt,
                  placeBikeBt, placeCoalBt, placeVoltaBt, placeFireBt };

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

        // Non fonctionnel
        placeDestroyButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeDestroyButton);
            OnDestroyPlacement?.Invoke();
        });
        //
        placeEolienneBt.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeEolienneBt);
            OnEoliennePlacement?.Invoke();
        });
        placeBuildingBt.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeBuildingBt);
            OnBuildingPlacement?.Invoke();
        });
        placeEcoBuildingBt.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeEcoBuildingBt);
            OnEcoBuildingPlacement?.Invoke();
        });
        placePoliceBt.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placePoliceBt);
            OnPolicePlacement?.Invoke();
        });
        placeTrashBt.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeTrashBt);
            OnTrashPlacement?.Invoke();
        });
        placeEcoTrashBt.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeEcoTrashBt);
            OnEcoTrashPlacement?.Invoke();
        });
        placeBikeBt.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeBikeBt);
            OnBikePlacement?.Invoke();
        });
        placeCoalBt.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeBikeBt);
            OnCoalPlacement?.Invoke();
        });
        placeVoltaBt.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeVoltaBt);
            OnVoltaPlacement?.Invoke();
        });
        placeFireBt.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeFireBt);
            OnFirePlacement?.Invoke();
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
