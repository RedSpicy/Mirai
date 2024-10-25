using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �ړ�����(���ʂɈړ�)
        Vector3 pos = transform.position;
        pos += transform.forward * speed ;
        transform.position = pos;

        // �Ƃ肠����Y���W�����ȉ��Ȃ����
        if(this.transform.position.y < 1.5)
        {
            Destroy(this.gameObject);
        }
    }

    // �v���C���[���̓����蔻��
    void OnCollisionEnter(Collision collision)
    {
        // ��
        if (collision.gameObject.tag == "wall")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // �W���H
        if (other.gameObject.tag == "backMarker")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
        }
        if (other.gameObject.tag == "leftMarker")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (other.gameObject.tag == "rightMarker")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (other.gameObject.tag == "frontMarker")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
            Debug.Log("hitfront");
        }
    }
}
