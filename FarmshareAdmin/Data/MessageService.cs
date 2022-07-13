namespace FarmshareAdmin.Data
{
    using gl = Globals;
    public class MessageService
    {
        static public void AddWarningMessage(List<Message> msgList, string content)
        {
            msgList.Add(new Message { status = gl.msgWarning, content = content });
        }

        static public void AddErrorMessage(List<Message> msgList, string content)
        {
            msgList.Add(new Message { status = gl.msgDanger, content = content });
        }

        static public void AddSuccessMessage(List<Message> msgList, string content)
        {
            msgList.Add(new Message { status = gl.msgSuccess, content = content });
        }

        static public void FinalPostMessage(List<Message> msgList, bool success, int fieldErrorCount)
        {
            if (success)
                msgList.Add(new Message { status = gl.msgSuccess, content = "Update Successful" });
            else if (fieldErrorCount > 0)
                msgList.Add(new Message { status = gl.msgDanger, content = "See below for field specific errors" });
        }
    }
}
