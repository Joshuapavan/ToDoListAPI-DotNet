using System;
using AutoMapper;
using ToDoListAPI.Dtos;
using ToDoListAPI.Models;

namespace ToDoListAPI.Helpers;

public class AutomapperProfiles : AutoMapper.Profile
{
    public AutomapperProfiles()
    {
        CreateMap<RegisterDto, User>();
        CreateMap<LoginDto, User>();
    }

}
