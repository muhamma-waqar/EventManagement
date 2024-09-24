using SchoolManagement.Contracts;
using System.ServiceModel;

namespace SchoolManagement.Grpc
{
    [ServiceContract(Name = "School.Student.TestGrpcStream")]
    interface ITestGrpcServerStreaming
    {
        [OperationContract(Name = "GetStudentStream")]
        IAsyncEnumerable<StudentStreamingResponse> GetStudentStream(StudentSteamingRequest student);
    }
}
