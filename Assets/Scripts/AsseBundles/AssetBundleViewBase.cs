using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleViewBase : MonoBehaviour
{
    //private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=1T421xe5jkQWiCUI_F6T9_F4wqKF4UnRn";
    private const string UrlAssetBundleAudio = "https://drive.google.com/uc?export=download&id=1aS74W78jBKtRrHXU-BkbElpZr_-cvPvw";

    private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=1HbBChmGMHkVMtUzMC4In55U5n1PCCkDE";

    //Моя ссылка - https://drive.google.com/file/d/1HbBChmGMHkVMtUzMC4In55U5n1PCCkDE/view?usp=sharing

    [SerializeField]
    private DataSpriteBundle[] _dataSpriteBundles;

    [SerializeField]
    private DataAudioBundle[] _dataAudioBundles;

    private AssetBundle _spritesAssetBundle;
    private AssetBundle _audioAssetBundle;

    protected IEnumerator DownloadAndSetAssetBundle()
    {
        yield return GetSpritesAssetBundle();
        yield return GetAudioAssetBundle();

        if (_spritesAssetBundle == null || _audioAssetBundle == null)
        {
            Debug.LogError("Error in asset bundle");
            yield break;
        }

        SetDownloadAsset();
        yield return null;
    }

    private void SetDownloadAsset()
    {
        foreach(var data in _dataSpriteBundles)
            data.Image.sprite = _spritesAssetBundle.LoadAsset<Sprite>(data.NameAssetBundle);

        foreach (var data in _dataAudioBundles)
        {
            data.AudioSource.clip = _audioAssetBundle.LoadAsset<AudioClip>(data.NameAssetBundle);
            data.AudioSource.Play();
        }
    }

    private IEnumerator GetAudioAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleAudio);

        yield return request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        StateRequest(request, ref _audioAssetBundle);
    }

    private IEnumerator GetSpritesAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);

        yield return request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        StateRequest(request, ref _spritesAssetBundle);
    }

    private void StateRequest(UnityWebRequest request, ref AssetBundle assetBundle)
    {
        if (request.error == null)
        {
            assetBundle = DownloadHandlerAssetBundle.GetContent(request);
           // Debug.LogError("COMPLETE!!!");
        }
        else
        {
            //Debug.LogError(request.error);
        }
    }
}
