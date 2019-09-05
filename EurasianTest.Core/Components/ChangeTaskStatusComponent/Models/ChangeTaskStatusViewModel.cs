using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.ChangeTaskStatusComponent.Models
{
    public class ChangeTaskStatusViewModel
    {
        public Int64 Id { set; get; }

        public TaskStatus Status { set; get; }

        public Int64 UserId { set; get; }
    }
}
