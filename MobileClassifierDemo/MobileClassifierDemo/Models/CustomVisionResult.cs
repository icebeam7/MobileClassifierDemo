using System;
using System.Collections.Generic;

namespace MobileClassifierDemo.Models
{
    public class CustomVisionResult
    {
        public string Id { get; set; }
        public string Project { get; set; }
        public string Iteration { get; set; }
        public DateTime Created { get; set; }
        public List<Prediction> Predictions { get; set; }
    }
}
