using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MainScreenBackgroundimage : MonoBehaviour
{

    public string imageUrl = "https://i.pinimg.com/564x/ab/dc/7c/abdc7c2e51ba059be8b51bffc159f5b5.jpg";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetImage(imageUrl));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetImage(string imageUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(request) as Texture2D;
            GetComponent<Image>().sprite = Sprite.Create(downloadedTexture, new Rect(0, 0, downloadedTexture.width, downloadedTexture.height), new Vector2(0, 0));
        }
    }
}



