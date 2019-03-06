using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{

    public Texture2D sourceSprite;


    Color wallColor = new Color(1, 0, 1, 1);

    int verticalPlacement = 0;
    int horizontalPlacement = 0;

    GameObject wallPrefab;

    Mesh wallMesh;
    Bounds wallBounds;

    private void Awake()
    {
        wallPrefab = Resources.Load("Prefabs/Wall") as GameObject;
        wallMesh = wallPrefab.GetComponent<MeshFilter>().sharedMesh;
        wallBounds = wallMesh.bounds;
    }


    void Start()
    {
        Color[] pixels = sourceSprite.GetPixels();
        for (int i = 0; i < pixels.Length; i++)
        {
            horizontalPlacement++;

            if (pixels[i] == wallColor)
            {   
                CreateNewWall(horizontalPlacement, verticalPlacement);
            }

            if (horizontalPlacement == sourceSprite.width)
            {
                verticalPlacement++;
                horizontalPlacement = 0;
            }
        }
    }

    void CreateNewWall(int horizontalPlacement, int verticalPlacement)
    {
        var newWall = Instantiate(wallPrefab, transform);
        newWall.transform.position = new Vector3(horizontalPlacement * wallBounds.size.x, 0, verticalPlacement * wallBounds.size.z);
    }
}
