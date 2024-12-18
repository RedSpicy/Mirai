using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    public float radius = 100f;   // 円の半径
    public int segments = 100;    // 円を構成するセグメント数（数が多いほど滑らかになります）

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();  // LineRendererを追加
        lineRenderer.positionCount = segments + 1;  // セグメント数に応じて位置を設定
        lineRenderer.loop = true;  // 最後と最初を結ぶ

        DrawCircleShape();
    }

    void DrawCircleShape()
    {
        // 円の頂点を計算して設定
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i <= segments; i++)
        {
            float angle = i * Mathf.PI * 2 / segments;  // 角度の計算
            points[i] = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);  // X, Y座標の計算
        }
        lineRenderer.SetPositions(points);  // LineRendererに設定
    }
}
