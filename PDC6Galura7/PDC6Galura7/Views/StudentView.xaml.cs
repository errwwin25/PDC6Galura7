using PDC6Galura7.Models;
using PDC6Galura7.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDC6Galura7.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentView : ContentPage
    {
        public StudentView()
        {
            InitializeComponent();
            BindingContext = new StudentViewModel();
        }

        //OnItemSelected
        public async void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var student = args.Item as Student;
            if (student == null) return;

            await Navigation.PushAsync(new StudentDetailPage(student));
            lstStudent.SelectedItem = null;
        }
    }
}