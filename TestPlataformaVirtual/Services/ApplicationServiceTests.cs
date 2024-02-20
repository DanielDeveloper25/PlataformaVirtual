using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Assignments.Dtos;
using Application.Assignments.Interfaces;
using Application.Assignments.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Moq;
using Xunit;

public class AssignmentServiceTests
{
    [Fact]
    public async Task Add_ValidDto_ReturnsSaveDto()
    {
        // Arrange
        var repositoryMock = new Mock<IAssignmentRepository>();
        var mapperMock = new Mock<IMapper>();
        var assignmentService = new AssignmentService(repositoryMock.Object, mapperMock.Object);

        var createDto = new SaveAssignmentDto
        {
            Name = "Assignment Name",
            Instructions = "Assignment Instructions",
            DueDate = DateTime.Now.AddDays(7),
            SubjectId = 1
        };

        var assignment = new Assignment
        {
            Id = 1,
            Name = createDto.Name,
            Instructions = createDto.Instructions,
            DueDate = createDto.DueDate,
            SubjectId = createDto.SubjectId
        };

        var saveDto = new SaveAssignmentDto
        {
            Id = 1,
            Name = assignment.Name,
            Instructions = assignment.Instructions,
            DueDate = assignment.DueDate,
            SubjectId = assignment.SubjectId
        };


        mapperMock.Setup(mapper => mapper.Map<Assignment>(It.IsAny<SaveAssignmentDto>())).Returns(assignment);
        repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Assignment>())).ReturnsAsync(assignment);
        mapperMock.Setup(mapper => mapper.Map<SaveAssignmentDto>(It.IsAny<Assignment>())).Returns(saveDto);

        // Act
        var result = await assignmentService.Add(createDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(saveDto, result);
    }

    [Fact]
    public async Task Update_ValidDto_ReturnsTask()
    {
        // Arrange
        var repositoryMock = new Mock<IAssignmentRepository>();
        var mapperMock = new Mock<IMapper>();
        var assignmentService = new AssignmentService(repositoryMock.Object, mapperMock.Object);

        var updateDto = new SaveAssignmentDto
        {
            Name = "Assignment Name",
            Instructions = "Assignment Instructions",
            DueDate = DateTime.Now.AddDays(7),
            SubjectId = 1
        };

        var assignment = new Assignment
        {
            Id = 1,
            Name = updateDto.Name,
            Instructions = updateDto.Instructions,
            DueDate = updateDto.DueDate,
            SubjectId = updateDto.SubjectId
        };


        mapperMock.Setup(mapper => mapper.Map<Assignment>(It.IsAny<SaveAssignmentDto>())).Returns(assignment);

        await assignmentService.Update(updateDto, 1); 

    }
}
