using SchoolManagement.Contracts;

namespace SchoolManagement.Grpc
{
    public class TestGrpcService : ITestGrpc
    {
        public async Task<StudentResponse> GetStudent(StudentRequest student)
        {
            var stu =  new StudentResponse { Name = "Muhammad Waqar", RollNo = "1234", Marks = "0000", StudyProgram = "BSCS"};
            return  stu;
        }
    }
}
