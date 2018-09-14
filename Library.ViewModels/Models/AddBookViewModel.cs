﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels.Models
{
    public class AddBookViewModel : PublicationViewModel
    {
        public int YearOfPublishing { get; set; }
        public string Author { get; set; }
        public virtual ICollection<int> AddPublicationHousesIds { get; set; }

        public AddBookViewModel()
        {
            AddPublicationHousesIds = new List<int>();
        }
    }
}
