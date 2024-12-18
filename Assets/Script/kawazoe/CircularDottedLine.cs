using UnityEngine;

public class CircularDottedLine : MonoBehaviour
{
    public int segments = 50;       // �~���\������_�̐�
    public float radius = 5f;       // �~�̔��a
    public float gapSize = 0.3f;    // �_���̊Ԋu�i�����Ŏw��j
    public Color lineColor = Color.blue; // �_���̐F
    public float lineWidth = 0.5f;  // ���̑���

    private LineRenderer lineRenderer;

    void Start()
    {
        // LineRenderer�R���|�[�l���g��ǉ�
        lineRenderer = gameObject.AddComponent<LineRenderer>();

        // LineRenderer�̊�{�ݒ�
        lineRenderer.positionCount = segments + 1;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.loop = true;

        // �}�e���A����K�p�i���ߑΉ��j
        Material material = new Material(Shader.Find("Sprites/Default"));
        material.color = lineColor;
        lineRenderer.material = material;

        Vector3 center = transform.position;  // ��I�u�W�F�N�g�̈ʒu���擾

        // ���_���v�Z���Đݒ�
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i <= segments; i++)
        {
            float angle = i * Mathf.PI * 2 / segments;
            // �~�̍��W���v�Z���Ē��S�ʒu��������
            points[i] = new Vector3(Mathf.Cos(angle) * radius, 0.7f, Mathf.Sin(angle) * radius) + center;
        }
        lineRenderer.SetPositions(points);

        // �_�����ʂ�ݒ�
        SetDottedEffect();
    }

    void Update()
    {
        // �e�̒��S�����ɉ�]������
        transform.RotateAround(transform.parent.position, Vector3.up, 30f * Time.deltaTime);
    }

    void SetDottedEffect()
    {
        // �A���t�@�l�œ_���̌��ʂ����
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKey = new GradientColorKey[1];
        GradientAlphaKey[] alphaKey = new GradientAlphaKey[segments + 1];

        // �F��ݒ�i�P�F�j
        colorKey[0] = new GradientColorKey(lineColor, 0f);

        // �_���̊Ԋu���A���t�@�l�Őݒ�
        for (int i = 0; i <= segments; i++)
        {
            float t = (float)i / segments;
            alphaKey[i] = new GradientAlphaKey((t % gapSize) < (gapSize / 2) ? 1f : 0f, t);
        }

        // �O���f�[�V������ݒ�
        gradient.SetKeys(colorKey, alphaKey);
        lineRenderer.colorGradient = gradient;
    }
}
