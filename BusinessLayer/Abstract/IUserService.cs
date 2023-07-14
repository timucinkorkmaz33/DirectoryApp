using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReportService
    {
        void AddReport(Reports rp);
        void UpdateReport(Reports rp);
        List<Reports> GetAllReports();
        Reports GetReportById(int id);
    }
}
