using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AmazingAssets.AllTerrainTextures;

namespace AmazingAssets.AllTerrainTextures.Examples
{
    public class ExportBasemap : MonoBehaviour
    {
        public TerrainData terrainData;

        Texture2D basemapDiffuse;
        Texture2D basemapNormal;


        void OnDisable()
        {
            if (basemapDiffuse != null)
            {
                if (Application.isEditor)
                    GameObject.DestroyImmediate(basemapDiffuse);
                else
                    GameObject.Destroy(basemapDiffuse);
            }

            if (basemapNormal != null)
            {
                if (Application.isEditor)
                    GameObject.DestroyImmediate(basemapNormal);
                else
                    GameObject.Destroy(basemapNormal);
            }
        }

        void Start()
        {
            basemapDiffuse = terrainData.AllTerrainTextures(true, false).Basemap.Diffuse(0);
            basemapNormal = terrainData.AllTerrainTextures(true, false).Basemap.Normal(0);


            Material material = GetComponent<MeshRenderer>().material;

            material.SetTexture("_BaseColorMap", basemapDiffuse);

            material.SetTexture("_NormalMap", basemapNormal);
            material.EnableKeyword("_NORMALMAP");   //Enable normal map
        }
    }
}