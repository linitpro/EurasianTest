using EurasianTest.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.Entities.Implementations
{
    public class ProjectAdministrator: IEntity
    {
        public ProjectAdministrator() { }

        public ProjectAdministrator(Int64 userId, Int64 projectId)
        {
            this.IsDeleted = false;
            this.Created = DateTime.Now;
            this.ProjectId = projectId;
            this.UserId = userId;
        }

        public Int64 Id { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public Project Project { set; get; }

        public Int64 ProjectId { set; get; }

        public User User { set; get; }

        public Int64 UserId { set; get; }
    }
}
