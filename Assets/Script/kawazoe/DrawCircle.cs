using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    public float radius = 100f;   // �~�̔��a
    public int segments = 100;    // �~���\������Z�O�����g���i���������قǊ��炩�ɂȂ�܂��j

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();  // LineRenderer��ǉ�
        lineRenderer.positionCount = segments + 1;  // �Z�O�����g���ɉ����Ĉʒu��ݒ�
        lineRenderer.loop = true;  // �Ō�ƍŏ�������

        DrawCircleShape();
    }

    void DrawCircleShape()
    {
        // �~�̒��_���v�Z���Đݒ�
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i <= segments; i++)
        {
            float angle = i * Mathf.PI * 2 / segments;  // �p�x�̌v�Z
            points[i] = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);  // X, Y���W�̌v�Z
        }
        lineRenderer.SetPositions(points);  // LineRenderer�ɐݒ�
    }
}
