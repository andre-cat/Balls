using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class DynamicTiles : MonoBehaviour
{
    [SerializeField] private Vector2 endTilling;
    [SerializeField] private Vector2 stepTilling;

    private MeshRenderer meshRenderer;
    private Vector2 iniTilling;

    private void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        iniTilling = meshRenderer.material.mainTextureScale;
        StartCoroutine(RunTillingLoop());
    }

    private IEnumerator RunTillingLoop()
    {
        while (true)
        {
            while (Vector2.Distance(meshRenderer.material.mainTextureScale, endTilling) > 0.1)
            {
                meshRenderer.material.mainTextureScale += stepTilling;
                yield return null;
            }
            while (Vector2.Distance(meshRenderer.material.mainTextureScale, iniTilling) > 0.1)
            {
                meshRenderer.material.mainTextureScale -= stepTilling;
                yield return null;
            }
        }
    }

}
