using SchoolManagement.Contracts;
using System.ServiceModel;

namespace SchoolManagement.Grpc
{
    [ServiceContract(Name = "School.Student.TestGrpc")]
    public interface ITestGrpc
    {
        [OperationContract(Name = "GetStudent")]
        Task<StudentResponse> GetStudent(StudentRequest student);
    }
}
