namespace FileDataRetrieval.Models
{
    public class Root
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int OrmDirection { get; set; }
        public int TypeId { get; set; }
        public bool Status { get; set; }
        public object Description { get; set; }
        public List<DomainSourceBinding> DomainSourceBindings { get; set; }
        public List<DiagramNodePosition> DiagramNodePositions { get; set; }
        public List<object> Relations { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public object DeletedBy { get; set; }
        public object DeletionDate { get; set; }
        public string Id { get; set; }
        public int MaestroBlocksEntityState { get; set; }
    }
}
