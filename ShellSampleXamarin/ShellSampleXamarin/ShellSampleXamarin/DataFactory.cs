using ShellSampleXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShellSampleXamarin
{
    public static class DataFactory
    {
        public static IList<ExerciseClass> Classes { get; private set; }

        private static DateTime TodayAt(int hour, int minute)
        {
            return new DateTime(DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                hour, minute, 0);
        }

        static DataFactory()
        {

            Classes = new ObservableCollection<ExerciseClass>
            {
                new ExerciseClass
                {
                    ClassName = "Yoga",
                    Instructor = "Maharshi Patanjali",
                    ClassTime = TodayAt(8,00),
                },
                 new ExerciseClass
                {
                    ClassName = "ABS + Stretch",
                    Instructor = "David Hasslehoff",
                    ClassTime = TodayAt(9,30),
                },
                 //new ExerciseClass
                //{
                //    ClassName = "Body Sculpt",
                //    Instructor = "Sadie Terry",
                //    ClassTime = DateTime.Now.AddHours(3),
                //},
                 new ExerciseClass
                {
                    ClassName = "Cycle",
                    Instructor = "Lance Armstrong",
                    ClassTime = TodayAt(12,00),
                },
                 new ExerciseClass
                {
                    ClassName = "Aerobics",
                    Instructor = "Jacky Chan",
                    ClassTime = TodayAt(15,30),
                },

                                  new ExerciseClass
                {
                    ClassName = "Cycle",
                    Instructor = "Lance Armstrong",
                    ClassTime = TodayAt(12,00),
                },
                 new ExerciseClass
                {
                    ClassName = "Aerobics",
                    Instructor = "Jacky Chan",
                    ClassTime = TodayAt(15,30),
                },
                                  new ExerciseClass
                {
                    ClassName = "Cycle",
                    Instructor = "Lance Armstrong",
                    ClassTime = TodayAt(12,00),
                },
                 new ExerciseClass
                {
                    ClassName = "Aerobics",
                    Instructor = "Jacky Chan",
                    ClassTime = TodayAt(15,30),
                },
                                  new ExerciseClass
                {
                    ClassName = "Cycle",
                    Instructor = "Lance Armstrong",
                    ClassTime = TodayAt(12,00),
                },
                 new ExerciseClass
                {
                    ClassName = "Aerobics",
                    Instructor = "Jacky Chan",
                    ClassTime = TodayAt(15,30),
                },
                                  new ExerciseClass
                {
                    ClassName = "Cycle",
                    Instructor = "Lance Armstrong",
                    ClassTime = TodayAt(12,00),
                },
                 new ExerciseClass
                {
                    ClassName = "Aerobics",
                    Instructor = "Jacky Chan",
                    ClassTime = TodayAt(15,30),
                },
                                  new ExerciseClass
                {
                    ClassName = "Cycle",
                    Instructor = "Lance Armstrong",
                    ClassTime = TodayAt(12,00),
                },
                 new ExerciseClass
                {
                    ClassName = "Aerobics",
                    Instructor = "Jacky Chan",
                    ClassTime = TodayAt(15,30),
                },
                 new ExerciseClass
                {
                    ClassName = "Weights",
                    Instructor = "Arnold Schwarzenegger",
                    ClassTime = TodayAt(18,00),
                    IsLast = true
                },
            };
        }



        internal static ObservableCollection<Photo> GetPhotos(int n)
        {
            ObservableCollection<Photo> photos = new ObservableCollection<Photo>();

            for (int i = 1; i < n; i++)
            {
                photos.Add(new Photo
                {
                    PhotoUri = $"photo_{i}",
                    Title = $"Photo{i}",
                    Description = $"サンプルです",
                    DateTime = DateTimeOffset.Now,
                    Owner = null
                });
            }

            return photos;
        }


        public static ObservableCollection<Person> GetPeople(int n)
        {
            ObservableCollection<Person> people = new ObservableCollection<Person>();
            for (int i = 1; i < n; i++)
            {
                people.Add(new Person
                {
                    FirstName = $"FirstName {i}",
                    LastName = $"LastName {i}",
                    Age = i,
                    AvatarUrl = $"avatar_men_{i}",
                    AccountName = $"AccountName{i}",
                    AccountId = $"@AccountId{i}",
                    Description = "ここには自己紹介などが入ります.C#を使って仕事をしています.趣味でXamarin.Formsで遊んでいます.",
                });
            }

            return people;
        }



    }
}
