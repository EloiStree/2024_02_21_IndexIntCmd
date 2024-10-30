namespace Eloi.IID
{

    /// <summary>
    /// I am a class that reference a struct holdding inded and value as integer to transport it in the app.
    /// </summary>
    [System.Serializable]
    public class IndexIntCmdStructRef : I_IndexIntCmdSetGet
    {
        public IndexIntCmdStruct m_value = new IndexIntCmdStruct();
        public int GetCommandInt() { return m_value.GetCommandInt(); }
        public int GetIndexInt() { return m_value.GetIndexInt(); }
        public void GetCommandInt(out int value) => value = m_value.GetCommandInt();
        public void GetIndexInt(out int value) => value = m_value.GetIndexInt();

        public void SetIndexInt(int value) => m_value. SetIndexInt( value);

        public void SetCommandInt(int value) => m_value.SetCommandInt(  value);

        public void Set(I_IndexIntCmdGet reference)
        {
                if (reference == null)
                    return;
            SetIndexInt(reference.GetIndexInt());
            SetCommandInt(reference.GetCommandInt());
        }
    }

}