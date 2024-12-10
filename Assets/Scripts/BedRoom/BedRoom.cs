using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BedRoom 
{    
    public class BedRoom : MonoBehaviour
    {
        [Header("ÒıÓÃ")]
        [SerializeField] private Button quitButton;
        [SerializeField] private Button bedButton;

        private void Start()
        {
            quitButton.onClick.AddListener(QuitScene);
            bedButton.onClick.AddListener(GoNextDay);
        }

        public void GoNextDay()
            => TimeManager.Singleton.StartNewDay(8);

        public void QuitScene()
            => SceneLoadManager.Singleton.LoadScene("´óÌü");
    }

}

