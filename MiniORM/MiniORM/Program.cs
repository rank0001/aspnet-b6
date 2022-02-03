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
            Session session = new Session
            {
                Id = 3,
                DurationInHour = 5,
                LearningObjective = "to understand C# generics basic!"
            };
            Topic topic = new Topic
            {
                Id = 2,
                Title = "C# delegates",
                Description = "It's an advance topic!",
                Sessions = new List<Session>() { (Session)session }
            };
            Phone phone = new Phone()
            {
                Id = 21,
                Number = "01719369158",
                Extension = "7",
                CountryCode = "+880"
            };
            Address presentAddress = new Address()
            {
                Id = 10,
                City = "Dhaka",
                Country = "Bangladesh",
                Street = "sector-12"
            };
            Address permanentAddress = new Address()
            {
                Id = 6,
                City = "Kishoregonj",
                Country = "Bangladesh",
                Street = "Jamalpur"
            };
            AdmissionTest admissionTest = new AdmissionTest()
            {
                Id = 5,
                StartDate = new DateTime(2021, 12, 1),
                EndDate = new DateTime(2022, 1, 1),
                TestFees = 100.55
            };
            Instructor instructor = new Instructor()
            {
                Id = 3,
                Name = "Zubayer Ahmed",
                Email = "zubayerahmed232@gmail.com",
                PermanentAddress = (Address)permanentAddress,
                PresentAddress = (Address)presentAddress,
                PhoneNumbers = new List<Phone>() { (Phone)phone }
            };
            Course course = new Course()
            {
                Id = 2,
                Title = "Dot net course",
                Teacher = (Instructor)instructor,
                Topics = new List<Topic>() { (Topic)topic },
                Fees = 50000,
                Tests = new List<AdmissionTest>() { (AdmissionTest)admissionTest }
            };
            #endregion

            ISqlDataAccess<BaseId> sql = new SqlDataAccess<BaseId>();

            #region Insert
            //sql.Insert(course);
            #endregion

            #region Update
           // sql.Update(course);
            #endregion

            #region Delete
           // sql.Delete(course);
            //sql.Delete(1);
            #endregion

            #region Read
            ISqlDataAccess<Session> sessionForId = new SqlDataAccess<Session>();
            var oneSession = sessionForId.GetById(3);
            foreach (var sesssion in oneSession)
            {
                Console.WriteLine("ID: " + sesssion.Id + " Duration:" +
                    sesssion.DurationInHour +
                    " Learning Objective: " + sesssion.LearningObjective);
            }

            ISqlDataAccess<Phone> phones = new SqlDataAccess<Phone>();
            var allPhones = phones.GetAll();
            foreach (var mobile in allPhones)
            {
                Console.WriteLine("ID: " + mobile.Id + " Country Code: " +
                    mobile.CountryCode +
                    " Number : " + mobile.Number + " Extension: " + mobile.Extension);
            }

            #endregion
        }
    }
}
