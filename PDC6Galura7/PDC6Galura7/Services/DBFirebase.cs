using PDC6Galura7.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Firebase.Database;
using Firebase.Database.Query;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PDC6Galura7.Services
{
    class DBFirebase
    {
        FirebaseClient client;
        public DBFirebase()
        {
            client = new FirebaseClient("https://pdc6galura7-default-rtdb.firebaseio.com/");
        }

        public ObservableCollection<Student> getStudent()
        {
            var studentData = client
                .Child("Student")
                .AsObservable<Student>()
                .AsObservableCollection();

            return studentData;

        }

        internal Task DeleteStudent(int v)
        {
            throw new NotImplementedException();
        }

        internal Task DeleteStudent(string text1, string text2, int v)
        {
            throw new NotImplementedException();
        }

        public async Task AddStudent(int StudentID, string StudentName, string Course, int YearLevel, string Section)
        {
            Student em = new Student() { studentid = StudentID, studentname = StudentName, course = Course, yearlevel = YearLevel, section = Section };
            await client
                .Child("Student")
                .PostAsync(em);
        }

        internal Task UpdateStudent(string text1, string text2, int v)
        {
            throw new NotImplementedException();
        }

        //Delete and Update
        public async Task DeleteStudent(int StudentID, string StudentName, string Course, int YearLevel, string Section)
        {
            var toDeleteStudent = (await client
                  .Child("Student")
                  .OnceAsync<Student>()).FirstOrDefault
                  (a => a.Object.studentid == StudentID || a.Object.studentname == StudentName || a.Object.course == Course
                  || a.Object.yearlevel == YearLevel || a.Object.section == Section);
            await client.Child("Student").Child(toDeleteStudent.Key).DeleteAsync();

        }

        public async Task UpdateStudent(int StudentID, string StudentName, string Course, int YearLevel, string Section)
        {
            var toUpdateStudent = (await client
                .Child("Student")
                .OnceAsync<Student>()).FirstOrDefault
                (a => a.Object.studentid == StudentID || studentname == StudentName || course == Courseyearlevel == YearLevel || section == Section);

            Student e = new Student() { studentid = StudentID, studentname = StudentName, course = Course, yearlevel = YearLevel, section = Section };
            await client
                .Child("Student")
                .Child(toUpdateStudent.Key)
                .PutAsync(e);
        }
    }
}
