﻿using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, string description, int clientId, int freelancerId, decimal totalCost)
        {
            Title = title;
            Description = description;
            ClientId = clientId;
            FreelancerId = freelancerId;
            TotalCost = totalCost;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int ClientId { get; private set; }
        public User Client { get; private set; }
        public int FreelancerId { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
        public void Start()
        {
            if (Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.Started;
                StartedAt = DateTime.Now;
            }
        }
        public void Finish()
        {
            if(Status == ProjectStatusEnum.Started)
            {
                Status = ProjectStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            }
        }
        public void Cancel()
        {
            if(Status == ProjectStatusEnum.Created || Status == ProjectStatusEnum.Started)
                Status = ProjectStatusEnum.Cancelled;
        }
    }
}