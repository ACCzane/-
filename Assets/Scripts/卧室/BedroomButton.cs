using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bedroom 
{     
    public class BedroomButton : MonoBehaviour
    {
        [Header("ÒıÓÃ")]
        [SerializeField] private Button quitButton;
        [SerializeField] private Button nextButton;

        private void OnEnable()
        {
            quitButton.onClick.AddListener(QuitScene);
            nextButton.onClick.AddListener(GoNextDay);
        }

        private void OnDisable()
        {
            quitButton.onClick.RemoveAllListeners();
            nextButton.onClick.RemoveAllListeners();
        }

        public void GoNextDay()
            => TimeManager.Singleton.StartNewDay(8);

        public void QuitScene()
            => SceneLoadManager.Singleton.LoadScene("´óÌü");
    }

}
