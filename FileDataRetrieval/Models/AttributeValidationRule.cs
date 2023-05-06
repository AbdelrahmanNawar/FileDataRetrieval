namespace FileDataRetrieval.Models
{
    public class AttributeValidationRule
    {
        public string AttributeId { get; set; }
        public int ValdiationType { get; set; }
        public string ValidationValue { get; set; }
        public string ErrorMessage { get; set; }
        public int Order { get; set; }
        public object Attribute { get; set; }
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
