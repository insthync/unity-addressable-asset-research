using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SimpleLoadAndRelease : MonoBehaviour
{
    public AssetReferenceGameObject[] goRefs;
    public RefScriptableObject sc;

    private void Start()
    {
        LoadAsync();
    }

    private async void LoadAsync()
    {
        foreach (var goRef in goRefs)
        {
            var asyncOp = goRef.LoadAssetAsync();
            var prefab = await asyncOp.Task;
            var go = Instantiate(prefab);
            var go2 = Instantiate(prefab);
            var go3 = Instantiate(prefab);
            await Task.Delay(1000);
            Destroy(go);
            Destroy(go2);
            Destroy(go3);
            Addressables.Release(asyncOp);
        }

    }
}
