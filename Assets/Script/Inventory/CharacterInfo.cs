using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Slider expSlider;

    public void SetInfo(Character character, float maxExp = 100f)
    {
        nameText.text = $"{character.Name}";
        levelText.text = $"{character.Level}";

        expSlider.maxValue = maxExp;
        expSlider.value = character.EXP;
    }
}
