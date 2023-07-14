using BusinessLayer.Management;
using DataAccessLayer.EntityFramework;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryApp.Controllers
{
    public class CreateReportController : Controller
    {
        ReportManagement rpMan = new ReportManagement(new EFReportRepository());
        ContactInformationManagement contactMan = new ContactInformationManagement(new EFContactRepository());
       
        public async void SendMessage()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new System.Uri("amqps://xjbohwos:aOFgpAaIUa0TdPZzmegB66KwlmbeKLHL@hawk.rmq.cloudamqp.com/xjbohwos");
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("reportQueue", true, false, false);

            var directory = contactMan.GetAllContact();
            List<string> LocationName=new List<string>();
            foreach (var contact in directory)
            {
                if (LocationName.Contains(contact.Location) == false)
                {
                    LocationName.Add(contact.Location);//lokasyon adları alındı
                }
            }
            var data = contactMan.GetAllContact();//tüm iletişim bilgileri alındı
            foreach (var lcName in LocationName)
            {
               
                var locName=lcName;
                var usercount = data.Where(u => u.Location == lcName).Count();
                var phonecount = data.Where(u => u.Location == lcName && u.Phone!=null).Count();
                var tarih = DateTime.Now;
                var status=false;
                var Id = 0;
                var Allreports = rpMan.GetAllReports();
                if (Allreports.Count() == 0)
                {
                    Id = 1;
                }
                else
                {
                    Id = Allreports.Max(r => r.Id) + 1;
                }

                Reports reports = new Reports();
                reports.ReportDate = tarih;
                reports.ReportStatus = false;
                reports.UserCount = usercount;
                reports.UserPhoneCount = phonecount;
                reports.Location = locName;
                reports.Id= Id;

                //mesaj string olarak gönderiliyor ve alınan veriler veritabanında kayıt ediliyor.
                var mesaj = locName +","+usercount+","+phonecount+","+tarih+","+status+","+Id;
                var body = Encoding.UTF8.GetBytes(mesaj);
                channel.BasicPublish(string.Empty, "reportQueue", null, body);

                
                rpMan.AddReport(reports);   //rapor bilgileri veri tabanına ekleniyor.
            }
            
        }
    }
}
