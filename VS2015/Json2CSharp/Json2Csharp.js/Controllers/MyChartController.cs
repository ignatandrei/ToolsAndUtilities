using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Json2Csharp.js.Controllers
{
    public class RootObject
    {
        public List<string> labels { get; set; }
        public List<List<double>> series { get; set; }
    }
    public class MyChartController : ApiController
    {
        // GET: api/MyChart
        public RootObject Get()
        {
            var r= new RootObject()
            {
                labels = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" }
            };
            r.series=new List<List<double>>();
            r.series.Add(new List<double>()
            {12, 9, 7, 8, 5});
            r.series.Add(new List<double>()
            {2, 1, 3.5, 7, 3});
            r.series.Add(new List<double>()
            {1, 3, 4, 5, 6});

            return r;
        }

       
    }
}
