using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
namespace ShootEmUp.Animation.Tweening

{
    public class TitleTween : MonoBehaviour
    {
        [SerializeField]
        private TweenerCore<Vector3, Vector3, VectorOptions> _floatingTween;
        [SerializeField]
        private float _animationDurationFloating;
        [SerializeField]
        private float _animationDurationSliding;
        [SerializeField]
        private Ease _easeType;
        [SerializeField] [Range(0,1)]
        private float _coefficientEndValue;

        private void Start()
        {
             transform
                .DOMoveX(Screen.width/2, _animationDurationSliding)
                .SetEase(_easeType)
                .SetLoops(1)
                .OnStepComplete(StartFloating);
        }

        private void StartFloating()
        {
            _floatingTween =transform
                .DOMoveY(Screen.height*_coefficientEndValue, _animationDurationFloating)
                .SetEase(_easeType)
                .SetLoops(-1, LoopType.Yoyo); 
        }

        private void OnDestroy()
        {
            DOTween.KillAll();
        }
    }
}
