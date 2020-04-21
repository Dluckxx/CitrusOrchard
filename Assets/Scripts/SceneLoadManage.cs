using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoadManage : MonoBehaviour {

    // AsyncOperation m_AsyncOperation;
    // UnityAction<float> m_Progress;

    // void Update() {
    //     if (m_AsyncOperation != null) {
    //         if (m_Progress != null) {
    //             m_Progress(m_AsyncOperation.progress);
    //             m_Progress = null;
    //         }
    //     }
    // }

    // public void LoadScene(string name, UnityAction<float> progress, UnityAction finish) {
    //     new GameObject("#SceneLoadManager#").AddComponent<SceneLoadManage>();
    //     m_AsyncOperation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
    //     m_Progress = progress;

    //     m_AsyncOperation.completed += delegate(AsyncOperation obj) {
    //         finish();
    //         m_AsyncOperation = null;
    //     };
    // }

    public void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }
}