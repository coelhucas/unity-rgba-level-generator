using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RoomGenerator : MonoBehaviour
{

    public Texture2D sourceSprite;
    public InstanceEntry[] instancesToGenerate;

    int verticalPlacement = 0;
    int horizontalPlacement = 0;

    Mesh instanceMesh;
    Bounds instanceBounds;

    string outputPath = "Assets/Resources/Prefabs/GeneratedOutput/";

    void Start()
    {
        GenerateRoom(); 
    }

    void GenerateRoom()
    {
        Color[] spriteColors = sourceSprite.GetPixels();
        for (int i = 0; i < spriteColors.Length; i++)
        {
            horizontalPlacement++;
            foreach (InstanceEntry instanceEntry in instancesToGenerate)
            {
                if (spriteColors[i] == instanceEntry.sourceColor)
                {
                    GenerateNewInstance(instanceEntry.instancePrefab, horizontalPlacement, verticalPlacement);
                }
            }

            if (horizontalPlacement == sourceSprite.width)
            {
                verticalPlacement++;
                horizontalPlacement = 0;
            }
        }
        SaveAsPrefab();
    }

    void GenerateNewInstance(GameObject instanceToGenerate, int horizontalPlacement, int verticalPlacement)
    {
        var newInstance = Instantiate(instanceToGenerate, transform);
        instanceMesh = newInstance.GetComponent<MeshFilter>().sharedMesh;
        instanceBounds = instanceMesh.bounds;

        newInstance.transform.position = new Vector3(
                                        horizontalPlacement * instanceBounds.size.x, 
                                        0, 
                                        verticalPlacement * instanceBounds.size.z);
    }

    void SaveAsPrefab()
    {
        var uniqueInstanceName = string.Format(@"room-{0}.prefab", GUID.Generate());
        Destroy(this);
        PrefabUtility.SaveAsPrefabAsset(gameObject, outputPath + uniqueInstanceName);        
    }
}

[System.Serializable]
public class InstanceEntry
{
    public GameObject instancePrefab;
    public Color sourceColor;
}