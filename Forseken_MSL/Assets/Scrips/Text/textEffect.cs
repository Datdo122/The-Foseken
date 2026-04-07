using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class textEffect : MonoBehaviour
{
    public float blinkSpeed = 1f;
    [SerializeField] private TextMeshProUGUI textMeshPro; // 闪烁速度
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float alpha = Mathf.Abs(Mathf.Sin(Time.time * blinkSpeed)); // 计算alpha值，使其在0和1之间循环
        textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha); // 设置文本颜色的alpha值
    }
}
