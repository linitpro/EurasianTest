using EurasianTest.DAL.Configurations;
using EurasianTest.DAL.Entities.Implementations;
using EurasianTest.DAL.SelectionsDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<User> Users { set; get; }

        /// <summary>
        /// Истории задач
        /// </summary>
        public DbSet<TaskHistory> TaskHistories { set; get; }

        /// <summary>
        /// Задачи
        /// </summary>
        public DbSet<Task> Tasks { set; get; }

        /// <summary>
        /// Проекты
        /// </summary>
        public DbSet<Project> Projects { set; get; }

        /// <summary>
        /// Администраторы проектов
        /// </summary>
        public DbSet<ProjectAdministrator> ProjectAdministrators { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectAdministratorConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new TaskHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbQuery<GetHomeAdminInfoDTO> GetHomeAdminInfoQuery { set; get; }

        public DbQuery<GetTaskDTO> GetTasksQuery { set; get; }
    }
}
