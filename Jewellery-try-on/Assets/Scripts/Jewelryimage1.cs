using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Jewelryimage1 : MonoBehaviour
{
    //public string imageUrl = "https://www.kxan.com/wp-content/uploads/sites/40/2022/10/000_best-beauty-and-the-beast-jewelry-b02b8d.jpg";
    public string imageUrl = "https://i.pinimg.com/564x/f0/51/9d/f0519d23d4a42e86c7930bb53387bc14.jpg";

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
