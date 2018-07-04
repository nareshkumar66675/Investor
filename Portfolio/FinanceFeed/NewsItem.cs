﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.FinanceFeed
{
    public class NewsItem
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public DateTime PubDate { get; set; }
    }
}
