using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BL.Models;
using App.BL.Services;
using DotVVM.Framework.ViewModel;

namespace App.PL.ViewModels.CRUD
{
    public class DetailViewModel : App.PL.ViewModels.MasterPageViewModel
    {
        private readonly StudentService studentService;

        public DetailViewModel(StudentService studentService)
        {
            this.studentService = studentService;
        }

        public StudentDetailModel Student { get; set; }

        public override async Task PreRender()
        {
            int id = Convert.ToInt32(Context.Parameters["Id"]);
            Student = await studentService.GetStudentByIdAsync(id);
            await base.PreRender();
        }
        public async Task DeleteStudent()
        {
            await studentService.DeleteStudentAsync(Student.Id);
            Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
        }
    }
}

