namespace AspNetCoreDynamicForm.Models.FieldTypes
{
    public abstract class BaseField
    {
        public string Name { get; set; }
        public string EditorName => $"FieldEditors/{this.GetType().Name}";
    }
}