using MiniORM.Data_Access_Layer;
using MiniORM.Models;
using System;
using System.Collections.Generic;

namespace MiniORM
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Object Initialization
            BaseId session = new Session
            {
                Id = 33,
                DurationInHour = 5,
                LearningObjective = "to understand C# generics basic!"
            };
            BaseId topic = new Topic
            {
                Id = 34,
                Title = "C# delegates",
                Description = "It's an advance topic!",
                Sessions = new List<Session>() { (Session)session }
            };
            BaseId phone = new Phone()
            {
                Id = 93,
                Number = "01719369158",
                Extension = "7",
                CountryCode = "+880"
            };
            BaseId presentAddress = new Address()
            {
                Id = 300,
                City = "Dhaka",
                Country = "Bangladesh",
                Street = "sector-12"
            };
            BaseId permanentAddress = new Address()
            {
                Id = 203,
                City = "Kishoregonj",
                Country = "Bangladesh",
                Street = "Jamalpur"
            };
            BaseId admissionTest = new AdmissionTest()
            {
                Id = 503,
                StartDate = new DateTime(2021, 12, 1),
                EndDate = new DateTime(2022, 1, 1),
                TestFees = 100.55
            };
            BaseId instructor = new Instructor()
            {
                Id = 152,
                Name = "Zubayer Ahmed",
                Email = "zubayerahmed232@gmail.com",
                PermanentAddress = (Address)permanentAddress,
                PresentAddress = (Address)presentAddress,
                PhoneNumbers = new List<Phone>() { (Phone)phone }
            };
            BaseId course = new Course()
            {
                Id = 5,
                Title = "Dot net Course",
                Teacher = (Instructor)instructor,
                Topics = new List<Topic>() { (Topic)topic },
                Fees = 50000,
                Tests = new List<AdmissionTest>() { (AdmissionTest)admissionTest }
            };
            #endregion

            ISqlDataAccess<BaseId> sql = new SqlDataAccess<BaseId>();
            //sql.Insert(course);
            //sql.Update(course);
            //sql.Delete(course);
            ISqlDataAccess<Topic> session1 = new SqlDataAccess<Topic>();
            var lists = session1.GetAll();
            foreach (var item in lists)
            {
                
                Console.WriteLine(item.Id + " " + item.Title + " " + item.Description);
            }
        }
    }
}
