using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject Target;               // �÷��̾�

    public float offsetX = 0.0f;            // ī�޶��� x��ǥ
    public float offsetY = 7.0f;           // ī�޶��� y��ǥ
    public float offsetZ = -15.0f;          // ī�޶��� z��ǥ

    //Vector3���� �ѹ��� �޾Ƽ� ���ϴ� �͵� �ϳ��� ��� 

    public float CameraSpeed = 10.0f;       // ī�޶��� �ӵ�
    Vector3 TargetPos;                      // Ÿ���� ��ġ

    void Update()
    {
        TargetPos = new Vector3(Target.transform.position.x + offsetX, Target.transform.position.y + offsetY, Target.transform.position.z + offsetZ);
        // �÷��̾� ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����

        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        /*.Lerp(ȸ���� a����, ȸ���� b����, t�� �ӵ��� ȸ��)
           �츮�� �ڵ带 ���� "���� ȸ����(transform.rotation)���� �ٶ󺸴� ����(TargetPos) ���� 
           �츮�� ������ ȸ���ӵ�(Time.deltaTime?* CameaSpeed) (deltaTime�� �ӵ� ������)�� ȸ���Ѵ�"*/
    }
}
