using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class UltimoFinal : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            videoPlayer.Play();
            videoPlayer.loopPointReached += VideoEnded;
        }
    }

    void VideoEnded(VideoPlayer vp)
    {
        SceneManager.LoadScene(0);
    }
}
