using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayBGVid : MonoBehaviour
{

    public VideoPlayer bg_vid;
    // Start is called before the first frame update
    void Start()
    {
        bg_vid.url = System.IO.Path.Combine (Application.streamingAssetsPath,"BG_Vid.mp4");
    }


}
