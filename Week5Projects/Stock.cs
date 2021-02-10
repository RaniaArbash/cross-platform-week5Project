using System;
using System.Collections.Generic;

namespace Week5Projects
{
    public class Stock
    {
      public string symbol { get; set; }
      public string name { get; set; }
    }

    public class YahooModel
    {
        public string Query { get; set; }
        public List<Stock> Result { get; set; }
}
}
