namespace Tanks
{
    using UnityEngine;

    public class Explosion : MonoBehaviour
    {
        [SerializeField]
        private float _growthSize;
        [SerializeField]
        private float _growthRate;
        [SerializeField]
        private AudioClip[] _sounds;
        [SerializeField]
        private AudioSource _audioSource;

        private bool exploding = false;
        private float _totalGrowth = 0f;
        private float _startingGrowthSize;

        private void Start()
        {
            _startingGrowthSize = _growthSize;
        }

        public void Reset()
        {
            this.gameObject.SetActive(true);
            exploding = false;
            _growthSize = _startingGrowthSize;
        }
        public void Explode()
        {
            exploding = true;
            var sound = Random.Range(0, _sounds.Length);
            _audioSource.clip = _sounds[sound];
            _audioSource.Play();
        }

        private void FixedUpdate()
        {
            if (exploding)
            {
                if(_growthSize > 0f)
                {
                    this.transform.localScale = new Vector3(this.transform.localScale.x + _growthRate, this.transform.localScale.y + _growthRate, 0);
                    _growthSize -= _growthRate;
                    _totalGrowth += _growthRate;
                }
                else if(_totalGrowth > 0f)
                {
                    this.transform.localScale = new Vector3(this.transform.localScale.x - _growthRate, this.transform.localScale.y - _growthRate, 0);
                    _totalGrowth -= _growthRate;                    
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}