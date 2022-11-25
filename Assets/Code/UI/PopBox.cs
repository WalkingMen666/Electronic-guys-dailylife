using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopBox : MonoBehaviour
{
    protected AudioSource openAudio;
    protected AudioSource closeAudio;
    int Press = 0;
    public GameObject gameObject;
    Coroutine c = null;

    void Start()
    {
        openAudio = GameObject.Find("開啟音效").GetComponent<AudioSource>();
        closeAudio = GameObject.Find("關閉音效").GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Press == 0)
            {
                showPop(gameObject);
                Press = 1;
            }
            else
            {
                hidePop(gameObject);
                Press = 0;
            }
        }
    }

    public void showPop(GameObject g)
    {
        openAudio.Play();
        if (c != null) StopCoroutine(c);
        StartCoroutine(Pop(g, Vector3.one));
    }

    public void hidePop(GameObject g)
    {
        closeAudio.Play();
        if (c != null) StopCoroutine(c);
        StartCoroutine(Pop(g, Vector3.zero));
    }

    IEnumerator Pop (GameObject g, Vector3 v3)
    {
        float i = 0f;
        while(i < 1)
        {
            i += Time.deltaTime;
            g.transform.localScale = Vector3.Lerp(g.transform.localScale, v3, i);
            yield return new WaitForFixedUpdate();
        }
        c = null;
    }
    public void backtoMain()
    {
        SceneManager.LoadScene(0);
        Debug.Log("回到主選單");
    }
}
