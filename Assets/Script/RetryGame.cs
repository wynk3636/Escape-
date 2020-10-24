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

    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            var wPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(wPos, Vector2.zero);

            if (hit)
            {
                if (hit.collider.gameObject.name == this.name)
                {
                    doRetry();
                }
            }
        }
        */
    }

    public void OnClick()
    {
        Debug.Log("Retry");
        doRetry();
    }

    private void doRetry()
    {
        SceneManager.LoadScene(0);
    }
}
