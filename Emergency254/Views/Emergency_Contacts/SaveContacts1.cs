namespace Emergency254.Views.Emergency_Contacts
{
    public interface SaveContacts
    {
        string DataPartitionId { get; set; }
        string Logs { get; set; }
        string CountLogs { get; set; }
    }
}