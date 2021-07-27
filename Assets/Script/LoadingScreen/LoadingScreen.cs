using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peplayon
{
    public class LoadingScreen : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
