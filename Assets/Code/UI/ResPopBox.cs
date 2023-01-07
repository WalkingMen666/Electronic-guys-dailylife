using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResPopBox : MonoBehaviour
{
    protected AudioSource openAudio;
    protected AudioSource closeAudio;
    int Press = 0;
    public GameObject g;
    Coroutine c = null;

    void Start()
    {
        openAudio = GameObject.Find("開啟音效").GetComponent<AudioSource>();
        closeAudio = GameObject.Find("關閉音效").GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Press == 1)
        {
            hidePop(g);
            if (GameData.finishAllQue)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void showPop(GameObject g)
    {
        openAudio.Play();
        if (c != null) StopCoroutine(c);
        StartCoroutine(Pop(g, Vector3.one));
        Press = 1;
    }

    public void hidePop(GameObject g)
    {
        Press = 0;
        closeAudio.Play();
        if (c != null) StopCoroutine(c);
        StartCoroutine(Pop(g, Vector3.zero));
    }

    IEnumerator Pop(GameObject g, Vector3 v3)
    {
        float i = 0f;
        while (i < 1)
        {
            i += Time.deltaTime;
            g.transform.localScale = Vector3.Lerp(g.transform.localScale, v3, i);
            yield return new WaitForFixedUpdate();
        }
        c = null;
    }
}