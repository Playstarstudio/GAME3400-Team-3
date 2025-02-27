using UnityEngine;
using System.Collections.Generic; 

public class TerrainManager : MonoBehaviour
{
    public List<GameObject> terrainList; 

    public float spacingAmount = 100f;

    public void MoveTerrain(){
        GameObject firstTerrain = terrainList[0];
        GameObject lastTerrain = terrainList[4];
        firstTerrain.transform.position = new Vector3(firstTerrain.transform.position.x, firstTerrain.transform.position.y, lastTerrain.transform.position.z + spacingAmount);
        terrainList.RemoveAt(0);
        terrainList.Add(firstTerrain);
    }
}
