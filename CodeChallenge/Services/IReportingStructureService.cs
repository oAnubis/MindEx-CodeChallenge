using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Services
{
    public interface IReportingStructureService
    {
        ReportingStructure GetById(string id);
    }
}