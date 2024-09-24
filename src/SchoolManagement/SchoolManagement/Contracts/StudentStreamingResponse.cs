namespace SchoolManagement.Contracts
{
    using ProtoBuf;

    [ProtoContract]
    [CompatibilityLevel(CompatibilityLevel.Level300)]
    public class StudentStreamingResponse
    {
        [ProtoMember(1)]
        public string Name { get; set; } = string.Empty;
        [ProtoMember(2)]
        public string StudyProgram { get; set; } = string.Empty;
        [ProtoMember(3)]
        public string RollNo { get; set; } = string.Empty;
        [ProtoMember(4)]
        public string Marks { get; set; } = string.Empty;
    }
}
