using System;
using System.Collections.Generic;

namespace Reflection_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Course course = ObjectandDataInitializer();
            string json = JSONFormatter.Convert<Course>(course);
            Console.WriteLine(json);
        }

        private static Course ObjectandDataInitializer()
        {
            var course = new Course();
            var phone1 = new Phone();
            var phone2 = new Phone();
            var presentAddress = new Address();
            var permanentAddress = new Address();
            var instructor = new Instructor();
            var session1 = new Session();
            var session2 = new Session();
            var session3 = new Session();
            var session4 = new Session();
            var topic1 = new Topic();
            var topic2 = new Topic();
            var admissionTest1 = new AdmissionTest();
            var admissionTest2 = new AdmissionTest();
            phone1.Number = "01719369158";
            phone1.Extension = "7";
            phone1.CountryCode = "+880";
            phone2.Number = "01701036198";
            phone2.Extension = "9";
            phone2.CountryCode = "+880";
            presentAddress.City = "Dhaka";
            presentAddress.Country = "Bangladesh";
            presentAddress.Street = "sector-12";
            permanentAddress.City = "Kishoregonj";
            permanentAddress.Country = "Bangladesh";
            permanentAddress.Street = "Jamalpur";
            instructor.Name = "Ahmed Imtiaz";
            instructor.Email = "IamImtiaz@gmail.com";
            instructor.PermanentAddress = permanentAddress;
            instructor.PresentAddress = presentAddress;
            instructor.PhoneNumbers = new List<Phone> { phone1, phone2 };
            session1.DurationInHour = 2;
            session1.LearningObjective = "to understand C# generics basic!";
            session2.DurationInHour = 3;
            session2.LearningObjective = "to understand C# generics constraints!";
            session3.DurationInHour = 4;
            session3.LearningObjective = "to understand C# delegates!";
            session4.DurationInHour = 2;
            session4.LearningObjective = "to understand C# events!";

            topic1.Title = "C# Generics";
            topic1.Description = "It's an advance topic!";
            topic2.Title = "C# Delegates and Events";
            topic2.Description = "It is an advanced and important topic!";
            topic1.Sessions = new List<Session>() { session1, session2 };
            topic2.Sessions = new List<Session>() { session3, session4 };

            admissionTest1.StartDateTime = new DateTime(2021, 12, 1);
            admissionTest2.StartDateTime = new DateTime(2021, 10, 1);

            admissionTest1.EndDateTime = new DateTime(2022, 1, 1);
            admissionTest2.EndDateTime = new DateTime(2022, 2, 1);

            admissionTest1.TestFees = 5000.55;
            admissionTest2.TestFees = 5000.55;
            course.Title = "testing";
            course.Teacher = instructor;
            course.Topics = new List<Topic>() { topic1, topic2 };
            course.Fees = 30000;
            course.Tests = new List<AdmissionTest>() { admissionTest1, admissionTest2 };
            
            return course;
        }
    }
    

}
