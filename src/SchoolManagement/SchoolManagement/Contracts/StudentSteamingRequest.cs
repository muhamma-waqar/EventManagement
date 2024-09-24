using ProtoBuf;

namespace SchoolManagement.Contracts
{
    using ProtoBuf;

    [ProtoContract]
    [CompatibilityLevel(CompatibilityLevel.Level300)]
    public class StudentSteamingRequest
    {
        [ProtoMember(1)]
        public string Id { get; set; } = string.Empty;
    }
}
