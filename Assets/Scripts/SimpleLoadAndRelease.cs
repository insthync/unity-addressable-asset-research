using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

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
        List<AsyncOperationHandle<GameObject>> handles = new List<AsyncOperationHandle<GameObject>>();
        foreach (var goRef in goRefs)
        {
            var asyncOp = goRef.LoadAssetAsync();
            handles.Add(asyncOp);
            var prefab = await asyncOp.Task;
            var go = Instantiate(prefab);
            var go2 = Instantiate(prefab);
            var go3 = Instantiate(prefab);
            await Task.Delay(1000);
            Destroy(go);
            Destroy(go2);
            Destroy(go3);
        }
        await Task.Delay(1000);
        foreach (var handle in handles)
        {
            Addressables.Release(handle);
        }
    }
}
