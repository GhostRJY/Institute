﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Institute
{
    class Person
    {
        private string m_lastName;
        public string LastName
        {
            get { return m_lastName; }
            set { m_lastName = value; }
        }

        private string m_middleName;
        public string MiddleName
        {
            get { return m_middleName; }
            set { m_middleName = value; }
        }

        private string m_firstName;
        public string FirstName
        {
            get { return m_firstName; }
            set { m_firstName = value; }
        }

        private DateTime m_dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return m_dateOfBirth; }
            set
            { 
                if(value > DateTime.MinValue && value<DateTime.MaxValue)
                m_dateOfBirth = value;
            }
        }

        private string m_address;
        public string Address
        {
            get { return m_address; }
            set { m_address = value; }
        }

        private string m_telephoneNumber;
        public string TelephoneNumber
        {
            get { return m_telephoneNumber; }
            set { m_telephoneNumber = value; }
        }

        //конструкторы
        public Person(string lastName,
                      string firstName,
                      string middleName,
                      DateTime dateOfBirth,
                      string address,
                      string telephoneNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            DateOfBirth = dateOfBirth;
            Address = address;
            TelephoneNumber = telephoneNumber;
        }

        public Person(in Person other)
        {
            LastName = other.LastName;
            FirstName = other.FirstName;
            MiddleName = other.MiddleName;
            DateOfBirth = other.DateOfBirth;
            Address = other.Address;
            TelephoneNumber = other.TelephoneNumber;
        }
        public override string ToString()
        {
            return $"Фамилия: {LastName}\n" +
                   $"Имя: {FirstName}\n" +
                   $"Отчество: {MiddleName}\n" +
                   $"Дата рождения: {DateOfBirth.ToShortDateString()}\n" +
                   $"Адрес: {Address}\n" +
                   $"Телефон: {TelephoneNumber}";
        }
    }
        class Student
    {
        private Person m_person;
        public Person Person
        {
            get { return m_person; }
            set 
            {
                m_person = value;  
            }
        }

        private List<int> m_exam;        
        private List<int> m_courseWork;
        private List<int> m_studentWork;
                
        public Student(in Person person)
        {
            m_person = new Person(person);
            m_exam = new List<int>();
            m_courseWork = new List<int>();
            m_studentWork = new List<int>();
        }
        public Student(in Student other)
        {
            m_person = new Person(other.m_person);
            m_exam = new List<int>(other.m_exam);
            m_courseWork = new List<int>(other.m_courseWork);
            m_studentWork = new List<int>(other.m_studentWork);
        }

        public Student(in Person person, in List<int> exam, in List<int> courseWork, in List<int> studentWork)
        {
            m_person = new Person(person);
            m_exam = new List<int>(exam);
            m_courseWork = new List<int>(courseWork);
            m_studentWork = new List<int>(studentWork);
        }

        public override string ToString()
        {
            return "\n----------------------------\n" + m_person.ToString() + "\n----------------------------";
        }

        ///добавление оценок
        public void AddExam(in int mark)
        {
            m_exam.Add(mark);
        }

        public void AddCourseWork(in int mark)
        {
            m_courseWork.Add(mark);
        }

        public void AddStudentWork(in int mark)
        {
            m_studentWork.Add(mark);
        }

        ///показ успеваемости
        public void ShowMarks()
        {
            ShowStudentWork();
            ShowCourseWork();
            ShowExams();
        }
        public void ShowExams()
        {
            Console.Write("Экзамены: {");
            foreach (var item in m_exam)
            {
                Console.Write(item + " ");
            }
            Console.Write("} ");
        }

        public void ShowCourseWork()
        {
            Console.Write("Курсовые работы: {");
            foreach (var item in m_courseWork)
            {
                Console.Write(item + " ");
            }
            Console.Write("} ");
        }

        public void ShowStudentWork()
        {
            Console.Write("Зачеты: {");
            foreach (var item in m_studentWork)
            {
                Console.Write(item + " ");
            }
            Console.Write("} ");
        }

        public double AverageMark()
        {
            if (m_exam.Count > 0 || m_studentWork.Count > 0 || m_courseWork.Count > 0)
            {
                int sum = 0;

                foreach (var item in m_exam)
                {
                    sum += item;
                }

                foreach (var item in m_courseWork)
                {
                    sum += item;
                }

                foreach (var item in m_studentWork)
                {
                    sum += item;
                }

                return sum / (m_exam.Count + m_courseWork.Count + m_studentWork.Count);
            }
            else
            {
                return 0;
            }
        }
        public void ShowAverageMark()
        {
            Console.WriteLine($"Средняя оценка: {AverageMark()}");
        }
    }
}
