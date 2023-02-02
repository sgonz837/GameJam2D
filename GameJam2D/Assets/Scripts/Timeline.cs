using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Timeline : MonoBehaviour
{
    public PlayableDirector timeline;
    public string nextSceneName;

    void Update()
    {
        if (timeline.state != PlayState.Playing)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
