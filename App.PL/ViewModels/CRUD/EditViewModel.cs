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
    public class EditViewModel : App.PL.ViewModels.MasterPageViewModel
    {
        private readonly StudentService studentService;

        public StudentDetailModel Student { get; set; }

        public EditViewModel(StudentService studentService)
        {
            this.studentService = studentService;
        }


        public override async Task PreRender()
        {
            int id = 0;
            if (int.TryParse(Context.Parameters["Id"].ToString(), out id))
            {
                Student = await studentService.GetStudentByIdAsync(id);
            }
            await base.PreRender();
        }


        public async Task EditStudent()
        {
            await studentService.UpdateStudentAsync(Student);
            Context.RedirectToRoute("CRUD_Detail", new { id = Student.Id });
        }
    }
}

