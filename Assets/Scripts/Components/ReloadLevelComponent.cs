using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Components
{
    public class ReloadLevelComponent : MonoBehaviour
    {
        public void OnReload()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}