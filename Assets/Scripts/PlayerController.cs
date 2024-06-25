using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float x, y;
    float speed = 0.2f;
    public float Lx, Ly, Rx, Ry, Ux, Uy, Dx, Dy, SPx, SPy;

    // Start is called before the first frame update
    void Start()
    {
        switch (GlobalVariables.dir)
        {
            case "right": transform.position = new Vector3(Rx, Ry); break; // 右から来た場合
            case "left": transform.position = new Vector3(Lx, Ly); break; // 左から来た場合
            case "up": transform.position = new Vector3(Ux, Uy); break; // 上から来た場合
            case "down": transform.position = new Vector3(Dx, Dy); break; // 下から来た場合
            default : transform.position = new Vector3(SPx, SPy); break; // それ以外（店から出てきたとき、戦闘後などに使う想定）

        }
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 vec = new Vector3(x, y);
        transform.position += vec.normalized * speed;
    }
}
