namespace Eloi.IID
{
    public static class IndexIntCmdDelegate
{
    public delegate void InterfaceGet(I_IndexIntCmdGet intCommandInterface);
    public delegate void InterfaceGetSet(I_IndexIntCmdGet intCommandInterface);
    public delegate void Int(int intCommand);
}

}