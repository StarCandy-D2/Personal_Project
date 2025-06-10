using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private CharacterInfo characterInfo;

    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI critText;
    [SerializeField] private Button backButton;

    public void OpenStatus()
    {
        gameObject.SetActive(true);
    }

    public void SetCharacterInfo(Character character)
    {
        characterInfo.SetInfo(character); // 이름, 레벨, EXP

        attackText.text = $"{character.Attack}";
        defText.text = $"{character.DEF}";
        hpText.text = $"{character.HP}";
        critText.text = $"{character.Crit * 100:F1}%";
    }

    private void Start()
    {
        backButton.onClick.AddListener(() =>
        {
            UIManager.Instance.MainMenu.OpenMainMenu();
        });
    }
}