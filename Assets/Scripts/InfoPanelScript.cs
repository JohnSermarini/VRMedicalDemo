using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class InfoPanelScript : MonoBehaviour
{
    private OrganManager om;

    private GameObject backPanel;
    private GameObject namePanel;
    private GameObject weightPanel;
    private GameObject descriptionPanel;
    private GameObject disorderPanel;

    private TextMesh nameText;
    private TextMesh weightText;
    private TextMesh descriptionText;
    private TextMesh disorderPrefixText;
    private TextMesh disorderText;

    void Start()
    {
        Init();
    }

    void Update()
    {

    }

    private void Init()
    {
        om = new OrganManager();

        backPanel = this.transform.GetChild(0).gameObject;
        namePanel = this.transform.GetChild(1).gameObject;
        weightPanel = this.transform.GetChild(2).gameObject;
        descriptionPanel = this.transform.GetChild(3).gameObject;
        disorderPanel = this.transform.GetChild(4).gameObject;

        nameText = namePanel.transform.GetChild(0).GetComponent<TextMesh>();
        weightText = weightPanel.transform.GetChild(0).GetComponent<TextMesh>();
        descriptionText = descriptionPanel.transform.GetChild(0).GetComponent<TextMesh>();
        disorderPrefixText = disorderPanel.transform.GetChild(0).GetComponent<TextMesh>();
        disorderText = disorderPanel.transform.GetChild(1).GetComponent<TextMesh>();
    }

    public void UpdateInfo(string organName)
    {
        Organ organ = om.GetOrgan(organName);

        nameText.text = organName;
        weightText.text = organ.weight;
        descriptionText.text = organ.description;
        disorderPrefixText.text = organ.disorderPrefix;

        int length = organ.disorderList.Count;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            sb.Append("- " + organ.disorderList[i]);

            if (i != length - 1)
            {
                sb.Append("\n");
            }
        }
    }
}
