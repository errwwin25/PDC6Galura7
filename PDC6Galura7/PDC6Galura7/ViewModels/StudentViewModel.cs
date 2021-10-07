using MvvmHelpers;
using PDC6Galura7.Models;
using PDC6Galura7.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PDC6Galura7.ViewModels
{
    class StudentViewModel : BaseViewModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set; }
        public int YearLevel { get; set; }
        public string Section { get; set; }

        private DBFirebase services;


        public Command AddStudentCommand { get;  }
        public ObservableCollection<Student> _students = new ObservableCollection<Student>();
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
                  
            }
        }

        public StudentViewModel()
        {
            services = new DBFirebase();
            Students = services.getStudent();
            AddStudentCommand = new Command(async () => await addStudentAsync(studentid, studentname, course, yearlevel, section));

        }

        public async Task addStudentAsync(int StudentID, string StudentName, string Course, int YearLevel, string Section)
        {
            await services.AddStudent(studentid, studentname, course, yearlevel, section);
        }
    
    }
}
