using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gladiator.Character
{
    public abstract class CharacterMovement : MonoBehaviour
    {
        protected Tween Tween;
        public void MoveDirection(Vector3 direction, float speed)
        {
            transform.position += direction * speed * Time.fixedDeltaTime;
        }

        public void Dash(Vector3 direction, float dashRange, float dashTime, Action onEnd = null)
        {
            Tween = transform.DOMove(transform.position + direction * dashRange, dashTime).SetEase(Ease.OutExpo).OnComplete(() => onEnd?.Invoke());
        }
    }
}
