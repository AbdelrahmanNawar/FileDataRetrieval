namespace FileDataRetrieval.Models
{
    public class DiagramNodePosition
    {
        public string XPosition { get; set; }
        public string YPosition { get; set; }
        public string RefId { get; set; }
        public int NodeTypeId { get; set; }
        public string DiagramId { get; set; }
        public object Diagram { get; set; }
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
