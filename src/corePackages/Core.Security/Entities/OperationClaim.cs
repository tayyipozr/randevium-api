﻿using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class OperationClaim : Entity
{
    public string Name { get; set; }

    public OperationClaim()
    {
    }

    public OperationClaim(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}