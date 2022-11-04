using UnityEngine;
using UnityEditor;

public class StageManager : MonoBehaviour
{
    //Like preloading in Godot?
    Object prefBall;

    private void Awake()
    {
        prefBall = AssetDatabase.LoadAssetAtPath("Assets/Ball/Ball.prefab", typeof(GameObject));
    }

    public void RespawnBall()
    {
        Instantiate(prefBall);
    }
}
