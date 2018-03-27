﻿using System.Collections.Generic;

namespace BAMCIS.PrestoClient.Model.Execution.PlanFlattener
{
    public class TableScanNode : PlanNode
    {
        public Table Table { get; set; }

        public IEnumerable<string> OutputSymbols { get; set; }

        /// <summary>
        /// The values of the keys are very dynamic in the serialized json
        /// </summary>
        public IDictionary<string, dynamic> Assignments { get; set; }

        public Layout Layout { get; set; }

        /// <summary>
        /// The values of the keys are very dynamic in the json serialization
        /// </summary>
        public IDictionary<string, dynamic> CurrentConstraint { get; set; }

        public string OriginalConstraint { get; set; }
        
    }
}