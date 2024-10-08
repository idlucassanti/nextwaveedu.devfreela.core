﻿using NextWaveEdu.Devfreela.Domain.Enums;

namespace NextWaveEdu.Devfreela.Application.ViewModels.Project
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, DateTime createdAt, ProjectStatusEnum status)
        {
            Id = id;
            Title = title;
            CreatedAt = createdAt;
            Status = status;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
    }
}
