using BusinessLayer.Management;
using DataAccessLayer.EntityFramework;
using DirectoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryApp.Controllers
{
    public class TakeReportController : Controller
    {
        ReportManagement rpMan = new ReportManagement(new EFReportRepository());
        public IActionResult Index()
        {
           
            return View();
        }

        public JsonResult GetallReports()
        {
            List<ReportsModelView> rpList = new List<ReportsModelView>();
            var allreports= rpMan.GetAllReports();
            foreach (var report in allreports)
            {
                ReportsModelView rp= new ReportsModelView();
                rp.rpModel = report;
                rp.ReportDurum = report.ReportStatus == true ? "Tamamlandı" : "Hazırlanıyor";
                rpList.Add(rp);
            }
            return Json(rpList);
        }
        public void readQueue()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new System.Uri("amqps://xjbohwos:aOFgpAaIUa0TdPZzmegB66KwlmbeKLHL@hawk.rmq.cloudamqp.com/xjbohwos");
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("reportQueue", true, false, false);
            var consumer=new EventingBasicConsumer(channel);
            channel.BasicConsume("reportQueue", true, consumer);
            consumer.Received += Consumer_Received;
        
        }

        public void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
           var data=Encoding.UTF8.GetString(e.Body.ToArray());
            //mesaj bilgi alınıyor ve alınan mesajdaki Id'ye göre gelen mesajlar güncelleniyor.
           var alldata=data.Split(',');
            var thisReport = rpMan.GetReportById(Convert.ToInt32(alldata[5]));
            thisReport.ReportStatus = true;
            rpMan.UpdateReport(thisReport); 
           //raporun durumu geldi hazırlandı olarak değiştirildi.
           
        }

      
    }
}
