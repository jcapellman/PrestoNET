using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BAMCIS.PrestoClient.Model.Sql.Planner.Plan
{
    /// <summary>
    /// From com.facebook.presto.sql.planner.plan.RemoteSourceNode.java
    /// </summary>
    public class RemoteSourceNode : PlanNode
    {
        #region Public Properties

        public IEnumerable<PlanFragmentId> SourceFragmentIds { get; }

        public IEnumerable<Symbol> Outputs { get; }

        #endregion

        #region Constructors

        [JsonConstructor]
        public RemoteSourceNode(PlanNodeId id, IEnumerable<PlanFragmentId> sourceFragmentIds, IEnumerable<Symbol> outputs) : base(id)
        {
            this.SourceFragmentIds = sourceFragmentIds;
            this.Outputs = outputs ?? throw new ArgumentNullException("outputs");
        }

        #endregion

        #region Public Methods

        public override IEnumerable<Symbol> GetOutputSymbols()
        {
            return this.Outputs;
        }

        public override IEnumerable<PlanNode> GetSources()
        {
            return new List<PlanNode>();
        }

        #endregion
    }
}
