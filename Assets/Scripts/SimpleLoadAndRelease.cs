using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SimpleLoadAndRelease : MonoBehaviour
{
    public AssetReferenceGameObject[] goRefs;

    private void Start()
    {
        LoadAsync();
    }

    private async void LoadAsync()
    {
        foreach (var goRef in goRefs)
        {
            var asyncOp = goRef.LoadAssetAsync();
            await asyncOp.Task;
            Addressables.Release(asyncOp);
        }

    }
}
