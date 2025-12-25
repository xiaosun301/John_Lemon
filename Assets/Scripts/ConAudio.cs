using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public static ConAudio Instance { get; private set; }
    public AudioClip WinAudio;
    public AudioClip FailAudio;
    void Start()
    {
        
    }

    public void OnPlayWinAudio(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(WinAudio, position, 2f);
    }
   public void OnPlayFailAudio(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(FailAudio, position, 2f);
    }
}
