namespace Tanks
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class AnyKeyListener : MonoBehaviour
    {
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}