using UnityEngine;

namespace Eloi.IID
{
    [System.Serializable]
public class IndexIntCmdDefault: I_IndexIntCmdSetGet
{
    [SerializeField] int m_index;
    [SerializeField] int m_command;

    public IndexIntCmdDefault()
    {
        m_index = 0;
        m_command = 0;
    }

    public IndexIntCmdDefault(int index, int command)
    {
        m_index = index;
        m_command = command;
    }

    public int GetCommandInt(){return m_command;}
    public int GetIndexInt(){return m_index;}
    public void GetCommandInt(out int value) => value = m_command;
    public void GetIndexInt(out int value) => value = m_command;

    public void SetIndexInt(int value) => m_index = value;

    public void SetCommandInt(int value) => m_command = value;

    public void Set(I_IndexIntCmdGet reference)
    {
            if(reference==null)
                return;

        SetIndexInt(reference.GetIndexInt());
        SetCommandInt(reference.GetCommandInt());
    }
}

}