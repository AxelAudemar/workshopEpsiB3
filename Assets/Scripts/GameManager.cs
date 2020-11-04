using SVS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraMovement cameraMovement;
    public RoadManager roadManager;
    public InputManager inputManager;

    public UIController uiController;

    public StructureManager structureManager;
    public PlacementManager placementManager;

    private void Start()
    {
        uiController.OnRoadPlacement += RoadPlacementHandler;
        uiController.OnHousePlacement += HousePlacementHandler;
        uiController.OnEoliennePlacement += EolienneHandler;
        uiController.OnBuildingPlacement += BuildingPlacementHandler;
        uiController.OnEcoBuildingPlacement += EcoBuildingPlacementHandler;
        uiController.OnPolicePlacement += PolicePlacementHandler;
        uiController.OnTrashPlacement += TrashPlacementHandler;
        uiController.OnEcoTrashPlacement += EcoTrashPlacementHandler;
        uiController.OnBikePlacement += BikePlacementHandler;
        uiController.OnCoalPlacement += CoalPlacementHandler;
        uiController.OnVoltaPlacement += VoltaPlacementHandler;
        uiController.OnFirePlacement += FirePlacementHandler;

        uiController.OnDestroyPlacement += DestroyHandler;
        
    }

    private void FirePlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlaceFire;
    }

    private void VoltaPlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlaceVolta;
    }

    private void CoalPlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlaceCoal;
    }

    private void BikePlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlaceBike;
    }

    private void EcoTrashPlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlaceEcoTrash;
    }

    private void TrashPlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlaceTrash;
    }

    private void PolicePlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlacePolice;
    }

    private void EolienneHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlaceEolienne;
    }
    private void DestroyHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.DestroyAssets;
    }

    private void BuildingPlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlaceBuilding;
    }

    private void HousePlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlaceHouse;
    }
    private void EcoBuildingPlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlaceEcoBuilding;
    }

    private void RoadPlacementHandler()
    {
        ClearInputActions();

        inputManager.OnMouseClick += roadManager.PlaceRoad;
        inputManager.OnMouseHold += roadManager.PlaceRoad;
        inputManager.OnMouseUp += roadManager.FinishPlacingRoad;
    }

    private void ClearInputActions()
    {
        inputManager.OnMouseClick = null;
        inputManager.OnMouseHold = null;
        inputManager.OnMouseUp = null;
    }

    private void Update()
    {
        cameraMovement.MoveCamera(new Vector3(inputManager.CameraMovementVector.x,0, inputManager.CameraMovementVector.y));
    }
}
