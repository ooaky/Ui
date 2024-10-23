using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens {

    public enum ScreenType {
        Panel,
        Info_Panel,
        SHop
    }
    public class ScreenBase : MonoBehaviour {
        public ScreenType screenType;
        public List<Transform> listOfObjectcs;
        public bool startHided = false;

        [Header("Animation")]
        public float animationDuration = .3f;
        public float delayBetweenObjects = .05f;

        private void Start() {
            if (startHided) {
                HideObjects();
            }
        }

        [Button]
        protected virtual void Show() {
            ShowObjects();
            Debug.Log("Show");
        }

        [Button]
        protected virtual void Hide() {
            Debug.Log("Show");
            HideObjects();
        }

        private void HideObjects() {
            listOfObjectcs.ForEach(i => i.gameObject.SetActive(false));
        }

        private void ShowObjects() {
            for (int i = 0; i < listOfObjectcs.Count; i++) {
                var obj = listOfObjectcs[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }
        }

        private void ForceShowObjects() {
            listOfObjectcs.ForEach(i => i.gameObject.SetActive(true));
        }
    }
}
