using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using XamarinFormsUiPractice.Models;

namespace XamarinFormsUiPractice
{
    public static class DataFactory
    {
        private static DateTime TodayAt(int hour, int minute)
        {
            return new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                hour, minute, 0);
        }

        static DataFactory()
        {
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



        public static List<EventItem> ReadEventSaveFile()
        {
            string json = "";

            if (File.Exists(App.EventSaveFilePath))
            {
                json = File.ReadAllText(App.EventSaveFilePath);
            }

            List<EventItem> eventItems;
            try
            {
                eventItems = JsonConvert.DeserializeObject<List<EventItem>>(json);
                if (eventItems is null)
                {
                    eventItems = new List<EventItem>();
                }
            }
            catch
            {
                eventItems = new List<EventItem>();
            }


            var today = DateTimeOffset.Now;
            return eventItems.Where(x =>
            {
                if (x.InsertDateTime.Year == today.Year &&
                    x.InsertDateTime.Month == today.Month &&
                    x.InsertDateTime.Day == today.Day)
                {
                    return true;
                }
                return false;
            }).ToList();
        }

        internal static void WriteEventSaveFile(IEnumerable<EventItem> eventItems)
        {
            var newJson = JsonConvert.SerializeObject(eventItems);

            File.WriteAllText(App.EventSaveFilePath, newJson);
        }
    }
}
