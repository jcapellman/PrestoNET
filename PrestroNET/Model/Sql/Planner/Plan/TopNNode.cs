using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BAMCIS.PrestoClient.Model.Sql.Planner.Plan
{
    /// <summary>
    /// From com.facebook.presto.sql.planner.plan.TopNNode.java
    /// </summary>
    public class TopNNode : PlanNode
    {
        #region Public Properties

        public PlanNode Source { get; }

        public long Count { get; }

        public OrderingScheme OrderingScheme { get; }

        public Step Step { get; set; }

        #endregion

        #region Constructors

        [JsonConstructor]
        public TopNNode(PlanNodeId id, PlanNode source, long count, OrderingScheme orderingScheme, Step step) : base(id)
        {
            ParameterCheck.OutOfRange(count >= 0, "count", "Count must be positive.");
            ParameterCheck.OutOfRange(count <= Int32.MaxValue, "count", $"ORDER BY LIMIT > {Int32.MaxValue} is not supported.");

            this.Source = source ?? throw new ArgumentNullException("source");
            this.Count = count;
            this.OrderingScheme = orderingScheme ?? throw new ArgumentNullException("orderingScheme");
            this.Step = step;
        }

        #endregion

        #region Public Methods

        public override IEnumerable<Symbol> GetOutputSymbols()
        {
            return this.Source.GetOutputSymbols();
        }

        public override IEnumerable<PlanNode> GetSources()
        {
            yield return this.Source;
        }

        #endregion
    }
}
