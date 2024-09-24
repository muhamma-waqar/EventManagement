using SchoolManagement.Contracts;

namespace SchoolManagement.Grpc
{
    public class TestGrpcStreamService : ITestGrpcServerStreaming
    {
        public async IAsyncEnumerable<StudentStreamingResponse> GetStudentStream(StudentSteamingRequest request)
        {
            var students = new List<StudentStreamingResponse>
            {
                new StudentStreamingResponse { Name = "John Doe", StudyProgram = "Mathematics", RollNo = "001", Marks = "A" },
                new StudentStreamingResponse { Name = "Jane Smith", StudyProgram = "Physics", RollNo = "002", Marks = "B+" }
            };

            foreach (var student in students)
            {
                yield return student;
                await Task.Delay(1000); // Simulate some delay
            }
        }
    }
}
