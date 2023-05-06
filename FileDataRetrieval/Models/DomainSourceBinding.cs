namespace FileDataRetrieval.Models
{
    public class DomainSourceBinding
    {
        public string DiagramId { get; set; }
        public object EntityId { get; set; }
        public string DomainSourceId { get; set; }
        public object Diagram { get; set; }
        public Entity Entity { get; set; }
        public object DomainSource { get; set; }
        public object CreatedBy { get; set; }
        public object CreationDate { get; set; }
        public object ModifiedBy { get; set; }
        public object ModificationDate { get; set; }
        public object DeletedBy { get; set; }
        public object DeletionDate { get; set; }
        public string Id { get; set; }
        public int MaestroBlocksEntityState { get; set; }
    }
}
