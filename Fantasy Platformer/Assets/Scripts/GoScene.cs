using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoScene : MonoBehaviour
{
    public void GoGo()
    {
        SceneManager.LoadScene(3);
    }
}
