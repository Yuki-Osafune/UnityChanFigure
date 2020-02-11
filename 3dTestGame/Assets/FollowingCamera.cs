using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, DisallowMultipleComponent]
public class FollowingCamera : MonoBehaviour
{
    public GameObject target; // an object to follow
    public Vector3 offset; // offset form the target object

    [SerializeField] private float distance = 2.0f; //オブジェクトとの距離
    [SerializeField] private float polarAngle = 75.0f; //Y軸のアングル
    [SerializeField] private float azimuthalAngle = 270.0f; //Z軸のアングル
    [SerializeField] private float minDistance = 1.0f;//最低距離
    [SerializeField] private float maxDistance = 7.0f;//最長距離
    [SerializeField] private float mouseXSensitivity = 5.0f;//X軸の移動速度
    [SerializeField] private float scrollSensitivity = 5.0f;//スクロールの速度
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {//マウス横移動で画面横に移動
            updateAngle(Input.GetAxis("Mouse X"));
        }
        //スクロールで距離変更
        updateDistance(Input.GetAxis("Mouse ScrollWheel"));

        var lookAtPos = target.transform.position + offset;
        updatePosition(lookAtPos);
        transform.LookAt(lookAtPos);
    }

    void updateAngle(float x/*, float y*/)
    {
        x = azimuthalAngle - x * mouseXSensitivity;
        azimuthalAngle = Mathf.Repeat(x, 360);
    }

    void updateDistance(float scroll)
    {
        scroll = distance - scroll * scrollSensitivity;
        distance = Mathf.Clamp(scroll, minDistance, maxDistance);
    }

    void updatePosition(Vector3 lookAtPos)
    {
        var da = azimuthalAngle * Mathf.Deg2Rad;
        var dp = polarAngle * Mathf.Deg2Rad;
        transform.position = new Vector3(
            lookAtPos.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
            lookAtPos.y + distance * Mathf.Cos(dp),
            lookAtPos.z + distance * Mathf.Sin(dp) * Mathf.Sin(da));
    }
}
