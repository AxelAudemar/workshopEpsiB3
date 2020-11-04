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

    // Settings
    public int CriticalPollution = 50; // At which value start population decrease

    // Electricity
    public int ElectricityProduction = 0;
    public int ElectricityConsumption = 0;

    //Population
    public int CurrentPopulation = 0;
    public int MaxPopulation = 0;

    private void Start()
    {
        uiController.OnRoadPlacement += RoadPlacementHandler;
        uiController.OnHousePlacement += HousePlacementHandler; // +4 Max Pop - Consume 2 Electricity
        uiController.OnEoliennePlacement += EolienneHandler; // +5 Electricity
        uiController.OnBuildingPlacement += BuildingPlacementHandler; // +16 Max Pop - Consume 10 Electricity
        uiController.OnEcoBuildingPlacement += EcoBuildingPlacementHandler;
        uiController.OnPolicePlacement += PolicePlacementHandler;
        uiController.OnTrashPlacement += TrashPlacementHandler;
        uiController.OnEcoTrashPlacement += EcoTrashPlacementHandler;
        uiController.OnBikePlacement += BikePlacementHandler;
        uiController.OnCoalPlacement += CoalPlacementHandler;
        uiController.OnVoltaPlacement += VoltaPlacementHandler;
        uiController.OnFirePlacement += FirePlacementHandler;

        uiController.OnDestroyPlacement += DestroyHandler;

        // Population Loop
        StartCoroutine(PopulationLife());
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

    public static void UpdateElectricityConsumption(int newValue) 
    {
        ElectricityConsumption += newValue;
    }

    public static int GetElectricityConsumption() 
    {
        return Electricity;
    }

    public static void UpdateElectricityProduction(int newValue) 
    {
        ElectricityProduction += newValue;
    }

    public static int GetElectricityProduction() 
    {
        return ElectricityProduction;
    }

    public static void UpdateCurrentPopulation(int newValue) 
    {
        CurrentPopulation += newValue;
    }

    public static int GetCurrentPopulation() 
    {
        return CurrentPopulation;
    }

    public static void UpdateMaxPopulation(int newValue) 
    {
        MaxPopulation += newValue;
    }

    public static int GetMaxPopulation() 
    {
        return MaxPopulation;
    }

    public static bool CanBuildNewStructure() 
    {
        if (GetElectricityConsumption()>GetElectricityProduction())
        {
            // TODO : Notification pas assez d'énergie
            return false;
        } else {
            return true;
        }
    }

    //Process management increase and decrease current population
    private IEnumerator PopulationLife() {
        while (true)
        {
            Debug.Log("Routine Pop");
            yield return new WaitForSeconds(5);
            if (GetScore() >= CriticalPollution) 
            {
               // Pollution high
               if (GetCurrentPopulation()>0) {
                   // Decrease Population
                   UpdateCurrentPopulation(-1);
               }
            } else {
               //Pollution OK
               if (GetCurrentPopulation()<GetMaxPopulation()) 
               {
                   // Increase Population
                   UpdateCurrentPopulation(1);
               } else {
                   // Current Population full
               }
            }
        }
    }
}
