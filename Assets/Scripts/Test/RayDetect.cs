using UnityEngine;
using System.Collections;

public class RayDetect : MonoBehaviour
{

    void Update()
    {
        // 以摄像机所在位置为起点，创建一条向下发射的射线  
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // 如果射线与平面碰撞，打印碰撞物体信息  
            Debug.Log("碰撞对象: " + hit.collider.name);
            // 在场景视图中绘制射线  
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
    }
}