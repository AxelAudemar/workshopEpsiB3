using SVS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StructureManager : MonoBehaviour
{
    public StructurePrefabWeighted[] housesPrefabe, buildingPrefabs, ecoBuildingPrefabs, eloPrefabs, firePrefabs, voltaPrefabs, coalPrefabs, 
                                     bikePrefabs, ecoTrashPrefabs, trashPrefabs, policePrefabs;
    public PlacementManager placementManager;

    private float[] houseWeights, buildingWeights, ecoBuildingWeights, eloPreWheights;

    private void Start()
    {
        houseWeights = housesPrefabe.Select(prefabStats => prefabStats.weight).ToArray();
        buildingWeights = ecoBuildingPrefabs.Select(prefabStats => prefabStats.weight).ToArray();
        ecoBuildingWeights = buildingPrefabs.Select(prefabStats => prefabStats.weight).ToArray();
        eloPreWheights = eloPrefabs.Select(prefabStats => prefabStats.weight).ToArray();
    }

    // Gestion des création via le bouton
    public void PlaceHouse(Vector3Int position)
    {
        if (CheckPositionBeforePlacement(position))
        {
            int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, housesPrefabe[randomIndex].prefab, CellType.Structure);
            //AudioPlayer.instance.PlayPlacementSound();
        }
    }
    public void PlaceEolienne(Vector3Int position)
    {
        placementManager.PlaceObjectOnTheMap(position, eloPrefabs[0].prefab, CellType.Structure);
        //AudioPlayer.instance.PlayPlacementSound();
    }

    public void PlaceBuilding(Vector3Int position)
    {
        if (CheckPositionBeforePlacement(position))
        {
            placementManager.PlaceObjectOnTheMap(position, buildingPrefabs[0].prefab, CellType.Structure);
        }
    }

    public void PlaceEcoBuilding(Vector3Int position)
    {
        if (CheckPositionBeforePlacement(position))
        {
            placementManager.PlaceObjectOnTheMap(position, ecoBuildingPrefabs[0].prefab, CellType.Structure);
        }
    }

    public void PlaceFire(Vector3Int position)
    {
        if (CheckPositionBeforePlacement(position))
        {
            placementManager.PlaceObjectOnTheMap(position, firePrefabs[0].prefab, CellType.Structure);
        }
    }

    public void PlaceVolta(Vector3Int position)
    {
        if (CheckPositionBeforePlacement(position))
        {
            placementManager.PlaceObjectOnTheMap(position, voltaPrefabs[0].prefab, CellType.Structure);
        }
    }

    public void PlaceCoal(Vector3Int position)
    {
        if (CheckPositionBeforePlacement(position))
        {
            placementManager.PlaceObjectOnTheMap(position, coalPrefabs[0].prefab, CellType.Structure);
        }
    }
    public void PlaceBike(Vector3Int position)
    {
        if (CheckPositionBeforePlacement(position))
        {
            placementManager.PlaceObjectOnTheMap(position, bikePrefabs[0].prefab, CellType.Structure);
        }
    }
    public void PlaceEcoTrash(Vector3Int position)
    {
        if (CheckPositionBeforePlacement(position))
        {
            placementManager.PlaceObjectOnTheMap(position, ecoTrashPrefabs[0].prefab, CellType.Structure);
        }
    }
    public void PlaceTrash(Vector3Int position)
    {
        if (CheckPositionBeforePlacement(position))
        {
            placementManager.PlaceObjectOnTheMap(position, trashPrefabs[0].prefab, CellType.Structure);
        }
    }
    public void PlacePolice(Vector3Int position)
    {
        if (CheckPositionBeforePlacement(position))
        {
            placementManager.PlaceObjectOnTheMap(position, policePrefabs[0].prefab, CellType.Structure);
        }
    }

    private int GetRandomWeightedIndex(float[] weights)
    {
        float sum = 0f;
        for (int i = 0; i < weights.Length; i++)
        {
            sum += weights[i];
        }

        float randomValue = UnityEngine.Random.Range(0, sum);
        float tempSum = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            //0->weihg[0] weight[0]->weight[1]
            if(randomValue >= tempSum && randomValue < tempSum + weights[i])
            {
                return i;
            }
            tempSum += weights[i];
        }
        return 0;
    }

    private bool CheckPositionBeforePlacement(Vector3Int position)
    {
        if (placementManager.CheckIfPositionInBound(position) == false)
        {
            Debug.Log("This position is out of bounds");
            return false;
        }
        if (placementManager.CheckIfPositionIsFree(position) == false)
        {
            Debug.Log("This position is not EMPTY");
            return false;
        }
        if(placementManager.GetNeighboursOfTypeFor(position,CellType.Road).Count <= 0)
        {
            Debug.Log("Must be placed near a road");
            return false;
        }
        return true;
    }
    public void DestroyAssets(Vector3Int position)
    {
        placementManager.DestroyItem(position);
    }
}

[Serializable]
public struct StructurePrefabWeighted
{
    public GameObject prefab;
    [Range(0,1)]
    public float weight;
}
