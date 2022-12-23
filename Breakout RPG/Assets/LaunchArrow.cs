using System.Collections;
using UnityEngine;

public class LaunchArrow : MonoBehaviour
{
    const float TAU = 6.28318530718f;
    public float maxRot = 0.5f;
    public float minRot = 0f;
    float rot;
    float rotRad;

    Vector2 right = Vector2.right;
    Vector2 left = Vector2.left;

    bool arrowLock = false;

    float timeElapsed;
    float duration = 3f;

    private void OnEnable()
    {
        //StartCoroutine(RotateArrow());
        timeElapsed = 0f;
    }

    private void Update()
    {
        if(arrowLock)
        {
            //rot = Mathf.Lerp(maxRot, minRot, timeElapsed / duration);
            rot = Mathf.PingPong(timeElapsed, maxRot);
            rotRad = rot * TAU;
            float newX = Mathf.Cos(rotRad);
            float newY = Mathf.Sin(rotRad);
            Vector2 newDir = new Vector2(newX, newY);
            Debug.DrawLine(transform.position, transform.position + (Vector3)newDir);
            print(newDir);
            timeElapsed += Time.deltaTime;

            if(Input.GetKeyDown("Space"))
            {
                arrowLock = false;
                this.enabled = false;
            }
        }
    }

    /*
    IEnumerator RotateArrow()
    {
        arrowLock = true;
        while(arrowLock)
        {
            Vector2 pt = Vector2.Lerp(left, right, Time.deltaTime);

            if (Input.GetKeyDown("Space"))
            {
                arrowLock = false;
                yield return pt;
            }

            yield return null;
        }
    }
    */
}
