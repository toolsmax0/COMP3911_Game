using UnityEngine;
using System.Collections;


/*press E to manipulate objects*/
public class InteractObj : MonoBehaviour
{
    public GameObject OneGameObject;//角色
    public GameObject TwoGameObject;//物体
    public float trans1;//获取角色当前的z坐标值
    public float trans2;//获取物体当前的z坐标值
    public float trans2_1;//获取物体当前的x坐标值
    public float trans2_2;//获取物体当前的y坐标值
                          // Use this for initialization
    void Start()
    {
        trans1 = OneGameObject.transform.position.z;
        trans2 = TwoGameObject.transform.position.z;
        trans2_1 = TwoGameObject.transform.position.x;
        trans2_2 = TwoGameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (trans2 <= 100 && trans2 <= trans1)
        {
            if (Input.GetKey(KeyCode.E) && trans2 > 0.5)//判断用户是否按下了E，并且当物体是否是在0.5以内
            {
                TwoGameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);
            }
            if (Input.GetKey(KeyCode.E) && trans2 <= 0.5) //判断用户是否按下了E，并且当物体是否是在0.5以外
            {
                TwoGameObject.transform.position = new Vector3(trans2, trans2_1, trans2_2);
            }
        }
    }
}
