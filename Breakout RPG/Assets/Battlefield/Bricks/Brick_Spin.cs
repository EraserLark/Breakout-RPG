using UnityEngine;

public class Brick_Spin : Brick_Base   //Inherits Base Brick class!
{
    public bool clockwise;
    public float speed = 30f;

    private void Update()
    {
        RotateBrick();
    }

    void RotateBrick()
    {
        int rotDir = 1;
        if(!clockwise)
        {
            rotDir = -1;
        }

        float rotAmt = speed * Time.deltaTime * rotDir;
        transform.Rotate(Vector3.forward, rotAmt);
    }
}
