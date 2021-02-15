namespace Tanks
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    public class PulseText : MonoBehaviour
    {
        private Text text;
        // Start is called before the first frame update
        void Start()
        {
            text = GetComponent<Text>();
            StartCoroutine(BlinkNumber());
        }

        private IEnumerator BlinkNumber()
        {
            while (true)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
                yield return new WaitForSeconds(1f);
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}