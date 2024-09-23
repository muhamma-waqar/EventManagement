namespace SchoolManagement.Contracts
{
    using ProtoBuf;

    [ProtoContract]
    [CompatibilityLevel(CompatibilityLevel.Level300)]
    public class StudentRequest
    {
        [ProtoMember(1)]
        public int Id { get; set; }
    }
}
