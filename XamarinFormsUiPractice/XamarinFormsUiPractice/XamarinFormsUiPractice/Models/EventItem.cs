using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace XamarinFormsUiPractice.Models
{
    [DataContract]
    public class EventItem : INotifyPropertyChanged
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTimeOffset InsertDateTime { get; set; }
        [DataMember]
        public DateTimeOffset UpdateDateTime { get; set; }
        public string AvatarUri { get; set; }

        [DataMember]
        private bool _isLast = false;
        public bool IsLast
        {
            get => _isLast;
            set
            {
                _isLast = value;
                OnPropertyChanged(nameof(IsLast));
            }
        }

        public EventItem()
        {
            Id = Guid.NewGuid().ToString();
            var currentDateTime = DateTimeOffset.Now;
            InsertDateTime = currentDateTime;
            UpdateDateTime = currentDateTime;
        }


        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
