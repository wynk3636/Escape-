using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(0);

            /*
            var wPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(wPos, Vector2.zero);

            if (hit)
            {
                if (hit.collider.gameObject.name == this.name)
                {
                    SceneManager.LoadScene(0);
                }
            }
            */
        }
    }
}
