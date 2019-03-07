using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RoomGenerator : MonoBehaviour
{

    public Texture2D sourceSprite;
    public Color wallColor = new Color(1, 0, 1, 1);

    int verticalPlacement = 0;
    int horizontalPlacement = 0;

    GameObject wallPrefab;

    Mesh wallMesh;
    Bounds wallBounds;

    string outputPath = "Assets/Resources/Prefabs/GeneratedOutput/";

    private void Awake()
    {
        wallPrefab = Resources.Load("Prefabs/Wall") as GameObject;
        wallMesh = wallPrefab.GetComponent<MeshFilter>().sharedMesh;
        wallBounds = wallMesh.bounds;
    }


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

            if (spriteColors[i] == wallColor)
            {
                CreateNewWall(horizontalPlacement, verticalPlacement);
            }

            if (horizontalPlacement == sourceSprite.width)
            {
                verticalPlacement++;
                horizontalPlacement = 0;
            }
        }
        SaveAsPrefab();
    }

    void CreateNewWall(int horizontalPlacement, int verticalPlacement)
    {
        var newWall = Instantiate(wallPrefab, transform);
        newWall.transform.position = new Vector3(horizontalPlacement * wallBounds.size.x, 0, verticalPlacement * wallBounds.size.z);
    }

    void SaveAsPrefab()
    {
        var uniqueInstanceName = string.Format(@"room-{0}.prefab", GUID.Generate());
        Destroy(this);
        PrefabUtility.SaveAsPrefabAsset(gameObject, outputPath + uniqueInstanceName);        
    }
}
