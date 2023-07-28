using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Management
{
    public class ReportManagement : IReportService
    {
        IReportDal _reportDal;

        public ReportManagement(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }

        public void AddReport(Reports rp)
        {
            _reportDal.Add(rp);
        }

        public List<Reports> GetAllReports()
        {
            return _reportDal.GetList();
        }

        public Reports GetReportById(int id)
        {
            return _reportDal.GetById(id);
        }

        public void UpdateReport(Reports rp)
        {
            _reportDal.Update(rp);
        }
    }
}
