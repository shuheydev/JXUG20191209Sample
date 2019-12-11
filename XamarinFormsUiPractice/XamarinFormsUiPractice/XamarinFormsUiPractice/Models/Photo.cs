using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsUiPractice.Models
{
    public class Photo
    {
        public string PhotoUri { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public Person Owner { get; set; }
    }
}
