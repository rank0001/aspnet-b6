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
            IId session = new Session
            {
                Id=5,
                DurationInHour = 2,
                LearningObjective = "to understand C# generics basic!"
            };
            IId topic = new Topic
            {
                Id = 3,
                Title="C# generics",
                Description="It's an advance topic!",
                Sessions=new List<Session>(){(Session) session}
            };
            IId phone = new Phone()
            {
                Id = 2,
                Number = "01719369158",
                Extension = "7",
                CountryCode = "+880"
            };
            IId presentAddress = new Address()
            {
                Id = 2,
                City = "Dhaka",
                Country = "Bangladesh",
                Street = "sector-12"
            };
            IId permanentAddress = new Address()
            {
                Id = 3,
                City = "Kishoregonj",
                Country = "Bangladesh",
                Street = "Jamalpur"
            };
            IId admissionTest = new AdmissionTest()
            {
                Id = 1,
                StartDate = new DateTime(2021, 12, 1),
                EndDate = new DateTime(2022, 1, 1),
                TestFees = 5000.55
            };
            IId instructor = new Instructor()
            {
                Id = 3,
                Name = "Ahmed Imtiaz",
                Email = "IamImtiaz@gmail.com",
                PermanentAddress = (Address)permanentAddress,
                PresentAddress = (Address)presentAddress,
                PhoneNumbers = new List<Phone>() { (Phone)phone }
            };
            IId course = new Course()
            {
                Id = 1,
                Title = "testing",
                Teacher = (Instructor)instructor,
                Topics = new List<Topic>() { (Topic)topic },
                Fees = 30000,
                Tests = new List<AdmissionTest>() {(AdmissionTest) admissionTest }
        };



            ISqlDataAccess<IId> sql = new SqlDataAccess<IId>();
            Console.WriteLine(sql.Insert(instructor));
        }
    }
}
