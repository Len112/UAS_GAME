using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;

public class SaveDataXmL : MonoBehaviour
{
    public string fileName = "PlayerData.xml";
    public InputField NewUsername;
    public InputField NewPassword;
    public InputField LoadNama;
    public InputField LoadNilai;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SaveNewUserXML()
    {
        var sr = File.CreateText(fileName);
        sr.WriteLine("<PlayerCollection>");
        sr.WriteLine("<Player>");
        sr.WriteLine("\t<Username>" + NewUsername.text + "<Username>");
        sr.WriteLine("\t<Password>" + NewPassword.text + "<Password>");
        sr.WriteLine("</Player>");
        sr.WriteLine("</PlayerCollection>");
        sr.Close();
    }

    
    public void LoadXML()
    {
        string xmlfile = System.IO.File.ReadAllText(fileName);
        XmlDocument xmldoc;
        XmlNodeList xmlNodeList;
        XmlNode xmlNode;
        xmldoc = new XmlDocument();
        xmldoc.LoadXml(xmlfile);
        xmlNodeList = xmldoc.GetElementsByTagName("Player");
        for (int i = 0; i <= xmlNodeList.Count - 1; i++)
        {
            xmlNode = xmlNodeList.Item(i);
            LoadNama.text = xmlNode.FirstChild.InnerText;
            LoadNilai.text = xmlNode.FirstChild.NextSibling.InnerText;
        }

    }
}
