using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.BL.Models;
using App.BL.Services;
using DotVVM.Framework.ViewModel;

namespace App.PL.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly StudentService studentService;

        public DefaultViewModel(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [Bind(Direction.ServerToClient)]
        public List<StudentListModel> Students { get; set; }

        public override async Task PreRender()
        {
            Students = await studentService.GetAllStudentsAsync();
            await base.PreRender();
        }
    }
}
