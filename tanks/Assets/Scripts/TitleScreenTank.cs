namespace Tanks
{
    using System;
    using System.Collections;
    using UnityEngine;

    public class TitleScreenTank : MonoBehaviour
    {
        [SerializeField]
        private Transform _barrelOrigin;
        [SerializeField]
        private Transform _tankBody;
        [SerializeField]
        private float _moveForward;
        [SerializeField]
        private float _moveSpeed;
        [SerializeField]        
        private float _rotateBarrel;
        [SerializeField]
        private float _rotateSpeed;
        [SerializeField]
        private Explosion _gunShot;
        [SerializeField]
        private Explosion _explosion;
        [SerializeField]
        private GameObject _otherTank;
        [SerializeField]
        private Explosion _secondaryExplosion1;
        [SerializeField]
        private Explosion _secondaryExplosion2;

        private readonly System.Random _random = new System.Random();

        private void Start()
        {
            StartCoroutine(Routine());
        }

        private IEnumerator Routine()
        {
            StartCoroutine(SecondaryExplosions());
            yield return StartCoroutine(Move());
            yield return StartCoroutine(RotateBarrel());
            yield return StartCoroutine(Fire());
            yield return StartCoroutine(Explode());            
        }

        private IEnumerator SecondaryExplosions()
        {
            while (true)
            {
                var next = _random.Next(0, 10);
                yield return new WaitForSeconds(next);
                _secondaryExplosion1.Reset();
                _secondaryExplosion1.Explode();
                next = _random.Next(0, 10);
                yield return new WaitForSeconds(next);
                _secondaryExplosion2.Reset();
                _secondaryExplosion2.Explode();
            }
        }

        private IEnumerator Move()
        {
            yield return new WaitForSeconds(1f);
            while (_moveForward > 0f)
            {
                _tankBody.position = new Vector3(_tankBody.position.x + (_moveSpeed * Time.fixedDeltaTime), _tankBody.position.y, 0f);
                _moveForward -= (_moveSpeed * Time.fixedDeltaTime);
                yield return new WaitForSeconds(0f);
            }
        }

        private IEnumerator RotateBarrel()
        {
            yield return new WaitForSeconds(1f);
            while (Math.Abs(_rotateBarrel) > 0f)
            {
                _barrelOrigin.Rotate(new Vector3(0f, 0f, _rotateSpeed));
                _rotateBarrel += _rotateSpeed;            
                yield return new WaitForEndOfFrame();
            }
        }

        private IEnumerator Fire()
        {
            yield return new WaitForSeconds(1f);
            _gunShot.Explode();
        }

        private IEnumerator Explode()
        {
            yield return new WaitForSeconds(1f);
            _explosion.Explode();
            yield return new WaitForSeconds(.5f);
            _otherTank.SetActive(false);
        }
    }
}